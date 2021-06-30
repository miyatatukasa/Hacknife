using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;
    SearchTrigger _search;
    IAttackable _attackable;

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
        // 最初にプレイヤーとなるオブジェクトの攻撃処理を呼ぶ
        _attackable = _info.Attack = _playObj.GetComponent<IAttackable>();
        _search = _info.PlayerObj.GetComponent<SearchTrigger>();
    }


    void Hacking(GameObject hitObj)
    {
        _info.PlayerObj = hitObj;
        _playObj = _info.PlayerObj;
        _attackable = _playObj.GetComponent<IAttackable>();
    }


    void MovePlayer(GameObject player)
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.localPosition += Vector3.forward * (Time.deltaTime * 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.localPosition += Vector3.forward * ((Time.deltaTime * -1) * 2);
        }*/

        /*長島追加*/
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
        player.transform.localPosition += velocity;
    }
    void FixedUpdate()
    {
        MovePlayer(_playObj);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_info.Sortings.Count == 0)
            {
                if (_search.IsSearch)
                {
                    Debug.Log("hack");
                    Hacking(PlayerInfo.Instance.Hack.MyObj);
                }
            }
        }
    }
}
