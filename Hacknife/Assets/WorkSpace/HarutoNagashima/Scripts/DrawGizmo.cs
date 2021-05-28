using UnityEditor;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
    [SerializeField]
    private SphereCollider searchArea;
    Transform EnemyTransform;
    Vector3 EnemyPos;

    // ÀÛ‚Ìõ“G”ÍˆÍ‚Æ‚ÍˆÙ‚È‚è•\¦‚³‚ê‚é‰~”ÍˆÍ‚Ì‘å‚«‚³‚Å‚·
    // õ“G”ÍˆÍ‚ği‚é‚É‚Íbolt‚É‚ ‚é“¯–¼‚Ì•Ï”‚ğ‘‚«Š·‚¦‚Ä‚­‚¾‚³‚¢
    [SerializeField, Tooltip("ÀÛ‚Ìõ“G”ÍˆÍ‚Å‚Í‚È‚­•\¦”ÍˆÍ‚Ì•Ï”‚Å‚·B’ˆÓ‚µ‚Ä‚­‚¾‚³‚¢")]
    private float searchAngle = 100f;

    private void OnDrawGizmos()
    {
        EnemyTransform = transform;
        EnemyPos = EnemyTransform.position+Vector3.down;
        Handles.color = Color.red;
        Handles.DrawSolidArc(EnemyPos, Vector3.up, Quaternion.Euler(0f, - searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
}
