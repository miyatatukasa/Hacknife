using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    private static GameManager _instance;

    // 索敵範囲の表示・非表示
    public bool SearchAreaView { get; set; }
    // 特定イベント時に動きを停止したいときに使用
    public bool TimeStop { get; set; } = false;
    // ゲームオーバー条件になった場合に使用（時間ないから）
    public bool GameOver { get; set; } = false;


    void Awake()
    {
        _instance = this;
    }

}
