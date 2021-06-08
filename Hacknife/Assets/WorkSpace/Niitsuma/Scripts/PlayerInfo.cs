using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance { get => _instance; }
    static PlayerInfo _instance;
    // ���G���
    public bool Scouting { get; set; } = false;
    // ���݃v���C���[�ɂȂ��Ă���I�u�W�F�N�g => ������J�����̒Ǐ]�Ώۂɂ���΂���
    public GameObject PlayerObj { get; set; }

    void Awake()
    {
        _instance = this;
    }
}
