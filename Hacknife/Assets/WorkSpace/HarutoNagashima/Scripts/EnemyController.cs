using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] points; // �ړI�n���i�[����z��
    private int destPoint = 0; // �ړI�n�̐�
    private NavMeshAgent agent; // �G�[�W�F���g

    void GotoNextPoint()
    {
        // �n�_�������ݒ肳��Ă��Ȃ��ƕԂ�
        if (points.Length == 0)
        {
            return;
        }

        // �G�[�W�F���g���ݒ肳�ꂽ�ڕW�n�_�ֈړ�����悤�ɂ���
        agent.destination = points[destPoint].position;

        // �z����̎��̈ʒu��ڕW�n�_�ɐݒ肷��
        // �K�v�ł���Ώo���n�_�ɖ߂�
        destPoint = (destPoint + 1) % points.Length;
    }

    void Start()
    {
        agent = transform.root.GetComponent<NavMeshAgent>();

        // autobreaking��false�ɂ���ƁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ�����悤�ɂȂ�
        // �G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă����x�𗎂Ƃ����ړ���������
        agent.autoBraking = false;
    }

    void Update()
    {
        // �G�[�W�F���g�����݂̖ڕW�n�_�ɋ߂Â��Ă����玟�̖ڕW�n�_��ݒ�
        if(!agent.pathPending&&agent.remainingDistance<0.5f)
        {
            GotoNextPoint();
        }
    }
}
