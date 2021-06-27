using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject _playObj;
    PlayerInfo _info;
    SearchTrigger _search;
    IAttackable _attackable;

    void Awake()
    {
        _info = PlayerInfo.Instance;
        // 最初のプレイヤー
        _info.PlayerObj = _playObj;
        // 最初にプレイヤーとなるオブジェクトの攻撃処理を呼ぶ
        _attackable = _info.Attack = _playObj.GetComponent<IAttackable>();
        _search = _info.PlayerObj.GetComponent<SearchTrigger>();
    }


    void Hacking(GameObject hit)
    {
        _info.PlayerObj = hit;
        _info.Hack = hit.GetComponent<IHackable>();
        _info.EnemyType = _info.Hack.GetEnemyType;
        _playObj = _info.PlayerObj;
        _search = _info.PlayerObj.GetComponent<SearchTrigger>();
        _attackable = _playObj.GetComponent<IAttackable>();
    }


    void MovePlayer(GameObject player)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.localPosition += Vector3.forward * (Time.deltaTime * 2);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.localPosition += Vector3.forward * ((Time.deltaTime * -1) * 2);
        }
    }
    void Update()
    {
        MovePlayer(_playObj);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_info.Sortings.Count == 0)
            {
                if (_search.IsSearch)
                {
                    Hacking(_search.GetSearchObj);
                    Debug.Log(_info.EnemyType);
                }
            }
        }
    }
}
