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
    Rigidbody rigidbody;

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

        /* // キャラクター移動処理
         velocity = new Vector3(h, 0, v);    // 上下のキー入力からZ軸の移動量を取得

         if (v > 0.1 || v < 0.1)
         {
             velocity *= MoveSpeed;       // 移動速度を掛ける
         }
         if (velocity.magnitude > 0.1)
         {
             // アニメーターに速度を渡す
             animator.SetFloat("Speed", velocity.magnitude);
             // 入力がある方向にキャラクターを移動させる
             player.transform.localPosition += velocity;
         }
         else
         {
             animator.SetFloat("Speed", 0f);
         }

         // キャラクター回転処理
         Vector3 diff = player.transform.position - playerPos;
         if (diff.magnitude > 0.01f)
         {
             player.transform.rotation = Quaternion.LookRotation(diff);
         }*/
    }
    void FixedUpdate()
    {
        /*playerPos = _playObj.transform.position;
        Debug.Log(playerPos);*/
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
