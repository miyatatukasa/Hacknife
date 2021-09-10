using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;

    /*長島追加*/
    // 移動速度
    [SerializeField]
    float MoveSpeed;
    // アニメーターの参照
    private Animator animator;
    // プレイヤーのポジション
    private Vector3 playerPos;
    private Vector3 velocity;
    private Rigidbody rigidbody;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // 最初のプレイヤー
        _info.PlayerObj = _playObj;
        // アニメーター取得
        animator = _playObj.GetComponent<Animator>();
    }

    void MovePlayer(GameObject player)
    {
        /*長島追加*/
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigidbody = player.GetComponent<Rigidbody>();

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = cameraForward * v + Camera.main.transform.right * h;
        rigidbody.velocity = moveForward * MoveSpeed + new Vector3(0, rigidbody.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            player.transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    void FixedUpdate()
    {
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
