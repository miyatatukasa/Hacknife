using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance { get => _instance; }
    static PlayerInfo _instance;
    // 索敵状態
    public bool Scouting { get; set; } = false;
    // 現在プレイヤーになっているオブジェクト => これをカメラの追従対象にすればいい
    public GameObject PlayerObj { get; set; }

    void Awake()
    {
        _instance = this;
    }
}
