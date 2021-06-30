using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float MoveSpeed;
    // スクリプトの参照
    PlayerInfo playerInfo;
    // 操作中のキャラクター
    GameObject Player;
    private Vector3 velocity;
    

    void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // キャラクター移動処理
        velocity = new Vector3(h, 0, v);    // 上下のキー入力からZ軸の移動量を取得

        if (v > 0.1 || v < 0.1)
        {
            velocity *= MoveSpeed;       // 移動速度を掛ける
        }


        // モデルのローカル空間での方向に変換
        velocity = transform.TransformDirection(velocity);

        // キー入力でキャラクターを移動させる
    }
}