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
    // ゲームオーバー条件になった場合に使用（時間ないから）
    public bool GameOver { get; set; } = false;


    void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameOver = true;
        }
    }

}
