using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;

    // 移動速度
    [SerializeField]
    float MoveSpeed;
    // アニメーター
    private Animator anim;
    // プレイヤーのリジッドボディ
    private Rigidbody rig;

    /// <summary>
    /// プレイヤーのリジッドボディの速度をアニメーターに設定する
    /// </summary>
    void ApplyAnimatorParameter()
    {
        var speed = Mathf.Abs(rig.velocity.magnitude);
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }

    /// <summary>
    /// カメラの向きを基準にしてプレイヤーを移動させる
    /// </summary>
    /// <param name="player"></param>
    void MovePlayer(GameObject player)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rig = player.GetComponent<Rigidbody>();

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;

        rig.velocity = moveForward * MoveSpeed + new Vector3(0, rig.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            player.transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // 最初のプレイヤー
        _info.PlayerObj = _playObj;
    }

    void Start()
    {
        // アニメーター取得
        anim = _playObj.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        MovePlayer(PlayerInfo.Instance.PlayerObj);
        ApplyAnimatorParameter();
    }
}
