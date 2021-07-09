using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;

    /*長島追加*/
    // 移動速度
    [SerializeField]
    float MoveSpeed;
    private Vector3 velocity;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // 最初のプレイヤー
        _info.PlayerObj = _playObj;
    }

    void MovePlayer(GameObject player)
    {
        /*長島追加*/
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // キャラクター移動処理
        velocity = new Vector3(h, 0, v);    // 上下のキー入力からZ軸の移動量を取得

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // 移動速度を掛ける
        }

        if (Input.GetKey(KeyCode.D))
        {
            player.transform.eulerAngles += Vector3.up * 2f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.eulerAngles -= Vector3.up * 2f;
        }


        // モデルのローカル空間での方向に変換
        velocity = player.transform.TransformDirection(velocity);

        // キー入力でキャラクターを移動させる
        player.transform.localPosition += velocity;
    }
    void FixedUpdate()
    {
        MovePlayer(PlayerInfo.Instance.PlayerObj);
    }
}
