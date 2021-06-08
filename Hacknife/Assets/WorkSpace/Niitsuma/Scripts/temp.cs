using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    
    // プレイヤーの変更処理のテンプレ

    void Start()
    {
        // プレイヤーオブジェクトを自分に設定
        // 最初のプレイヤーがStartで使う
        PlayerInfo.Instance.PlayerObj = this.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // 乗っ取り処理のテンプレ
            PlayerInfo.Instance.PlayerObj = collision.gameObject;
        }
    }
    
}
