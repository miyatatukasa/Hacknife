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
    
    // ���݃v���C���[�ɂȂ��Ă���I�u�W�F�N�g => ������J�����̒Ǐ]�Ώۂɂ���΂���
    public GameObject PlayerObj { get; set; }
    // �v���C���[�ƂȂ�I�u�W�F�N�g�̍U���������Z�b�g(Control�����ł�����󂯎�邾��)
    public IAttackable Attack { get; set; }
    // ���G���
    public bool Scouting { get; set; } = false;


    void Awake()
    {
        _instance = this;
    }
}
