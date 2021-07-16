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
    // 
    public IHackable Hack { get; set; }
    // ���݃n�b�L���O���Ă���G�l�~�[�̎��
    public CharactorType EnemyType { get; set; }
    // ���G���ꂽ��Add����
    public List<GameObject> Sortings { get => sortList; set => sortList = value; }
    List<GameObject> sortList = new List<GameObject>();
    // �n�b�L���O�ł��邩
    public bool CanHacking { get; set; }


    void Awake()
    {
        _instance = this;
    }
}