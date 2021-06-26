using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float MoveSpeed;
//     // カプセルコライダの参照
//     private CapsuleCollider col;
//     // リジッドボディの参照
//     private Rigidbody rb;
     // カプセルコライダの移動量
    private Vector3 velocity;
    // スクリプトの参照
    [SerializeField]
    private PlayerManagement playerManagement;
    // 現在操作しているキャラクター
    private GameObject nowPlayCharacter;

    void Start()
    {
        playerManagement = GetComponent<PlayerManagement>();

        nowPlayCharacter = playerManagement.NOW_PLAYCHARACTER;
    }
    void FixedUpdate()
    {
        nowPlayCharacter = playerManagement.NOW_PLAYCHARACTER;

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
        nowPlayCharacter.transform.localPosition += velocity * Time.fixedDeltaTime; // ここでnowPlayCharacterがnullになる キャラクター増やして試す
    }
}