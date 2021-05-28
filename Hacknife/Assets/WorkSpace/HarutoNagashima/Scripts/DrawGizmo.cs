using UnityEditor;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField]
    private SphereCollider searchArea;
    Transform EnemyTransform;
    Vector3 EnemyPos;

    // ���ۂ̍��G�͈͂Ƃ͈قȂ�\�������~�͈͂̑傫���ł�
    // ���G�͈͂��i��ɂ�bolt�ɂ��铯���̕ϐ������������Ă�������
    [SerializeField, Tooltip("���ۂ̍��G�͈͂ł͂Ȃ��\���͈͂̕ϐ��ł��B���ӂ��Ă�������")]
    private float searchAngle = 100f;

    private void OnDrawGizmos()
    {
        EnemyTransform = transform;
        EnemyPos = EnemyTransform.position+Vector3.down;
        Handles.color = Color.red;
        Handles.DrawSolidArc(EnemyPos, Vector3.up, Quaternion.Euler(0f, - searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
}
