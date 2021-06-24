using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public List<GameObject> charactersList = new List<GameObject>(); // 全てのキャラクターのリスト

    [HideInInspector]
    private GameObject nowPlayCharacter; // 操作中のキャラクター

    void Update()
    {
        foreach (GameObject i in charactersList)
        {
            Debug.Log("呼ばれた");
            if (i.transform.Find("isPlaying") == true) // 子オブジェクトのisPlayingが有効なら
            {
                Debug.Log("有効");
                nowPlayCharacter = i; // nowPlayCharacterに入れて終了
                break;
            }
        }

    }
    public GameObject NOW_PLAYCHARACTER => nowPlayCharacter;
}
