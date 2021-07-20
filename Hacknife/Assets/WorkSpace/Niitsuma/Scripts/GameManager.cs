using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => _instance; }
    private static GameManager _instance;

    // ���G�͈͂̕\���E��\��
    public bool SearchAreaView { get; set; }
    // �Q�[���I�[�o�[�����ɂȂ����ꍇ�Ɏg�p�i���ԂȂ�����j
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
