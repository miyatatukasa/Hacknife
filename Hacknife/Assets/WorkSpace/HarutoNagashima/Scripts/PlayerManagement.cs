using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviour
{
    public List<GameObject> charactersList = new List<GameObject>(); // �S�ẴL�����N�^�[�̃��X�g

    [HideInInspector]
    private GameObject nowPlayCharacter; // ���쒆�̃L�����N�^�[

    void Update()
    {
        foreach (GameObject i in charactersList)
        {
            Debug.Log("�Ă΂ꂽ");
            if (i.transform.Find("isPlaying") == true) // �q�I�u�W�F�N�g��isPlaying���L���Ȃ�
            {
                Debug.Log("�L��");
                nowPlayCharacter = i; // nowPlayCharacter�ɓ���ďI��
                break;
            }
        }

    }
    public GameObject NOW_PLAYCHARACTER => nowPlayCharacter;
}
