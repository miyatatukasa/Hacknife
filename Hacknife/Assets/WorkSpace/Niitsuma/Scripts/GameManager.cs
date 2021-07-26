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
    // ����C�x���g���ɓ������~�������Ƃ��Ɏg�p
    public bool TimeStop { get; set; } = false;
    // �Q�[���I�[�o�[�����ɂȂ����ꍇ�Ɏg�p�i���ԂȂ�����j
    public bool GameOver { get; set; } = false;


    void Awake()
    {
        _instance = this;
    }

}
