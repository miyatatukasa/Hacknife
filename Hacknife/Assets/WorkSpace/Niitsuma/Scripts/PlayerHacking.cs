using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxInput;

public class PlayerHacking : MonoBehaviour
{
    private PlayerInfo _info;
    private FowardSearch _search;
    //IAttackable _attackable;

    void Start()
    {
        _info = PlayerInfo.Instance;
        // 最初にプレイヤーとなるオブジェクトの攻撃処理を呼ぶ
        _search = _info.PlayerObj.GetComponent<FowardSearch>();
        //_attackable = _info.Attack = _playObj.GetComponent<IAttackable>();
    }


    void Hacking(GameObject hit)
    {
        _info.PlayerObj = hit;
        _info.Hack = hit.GetComponent<IHackable>();
        _info.EnemyType = _info.Hack.GetEnemyType;
        _search = _info.PlayerObj.GetComponent<FowardSearch>();
        //_attackable = _playObj.GetComponent<IAttackable>();
    }

    void Update()
    {

        if (_info.Sortings.Count == 0)
        {
            if (_search.IsSearch)
            {
                _info.CanHacking = true;
            }
            else
            {
                _info.CanHacking = false;
            }
        }
        else
        {
            _info.CanHacking = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B))
        {
            if (_info.CanHacking)
            {
                Hacking(_search.GetSearchObj);
            }
        }
    }
}
