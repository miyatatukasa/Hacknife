using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxInput;

public class PlayerHacking : MonoBehaviour {
    private PlayerInfo info;
    private FowardSearch search;
    //IAttackable _attackable;

    void Start() {
        info = PlayerInfo.Instance;
        // 最初にプレイヤーとなるオブジェクトの攻撃処理を呼ぶ
        search = info.PlayerObj.GetComponent<FowardSearch>();
        //_attackable = _info.Attack = _playObj.GetComponent<IAttackable>();
    }


    void Hacking(GameObject hit) {
        info.PlayerObj = hit;
        info.Hack = hit.GetComponent<IHackable>();
        info.EnemyType = info.Hack.GetEnemyType;
        search = info.PlayerObj.GetComponent<FowardSearch>();
        //_attackable = _playObj.GetComponent<IAttackable>();
    }

    void Update() {

        if (info.Sortings.Count == 0) {
            if (search.IsSearch) {
                info.CanHacking = true;
            }
            else {
                info.CanHacking = false;
            }
        }
        else {
            info.CanHacking = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) || XBXInput.PushDown(XBXBtn.B)) {
            if (info.CanHacking) {
                Hacking(search.GetSearchObj);
            }
        }
    }
}
