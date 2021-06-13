using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void ApplyAttack();
}


[DefaultExecutionOrder(-1)]
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance { get => _instance; }
    static PlayerInfo _instance;
    
    // 現在プレイヤーになっているオブジェクト => これをカメラの追従対象にすればいい
    public GameObject PlayerObj { get; set; }
    // プレイヤーとなるオブジェクトの攻撃処理をセット(Control処理でこれを受け取るだけ)
    public IAttackable Attack { get; set; }
    // 索敵状態
    public bool Scouting { get; set; } = false;


    void Awake()
    {
        _instance = this;
    }
}
