using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable {
    public void ApplyAttack();
}


[DefaultExecutionOrder(-1)]
public class PlayerInfo : MonoBehaviour {
    public static PlayerInfo Instance { get => instance; }
    static PlayerInfo instance;

    // 現在プレイヤーになっているオブジェクト => これをカメラの追従対象にすればいい
    public GameObject PlayerObj { get; set; }
    // プレイヤーとなるオブジェクトの攻撃処理をセット(Control処理でこれを受け取るだけ)
    public IAttackable Attack { get; set; }
    // 
    public IHackable Hack { get; set; }
    // 現在ハッキングしているエネミーの種類
    public CharactorType EnemyType { get; set; }
    // 索敵されたらAddする
    public List<GameObject> Sortings { get => sortList; set => sortList = value; }
    List<GameObject> sortList = new List<GameObject>();
    // ハッキングできるか
    public bool CanHacking { get; set; }
    // ボタンUIを表示するか
    public bool ShouldShowBtnUI { get; set; }


    void Awake() {
        instance = this;
    }
}
