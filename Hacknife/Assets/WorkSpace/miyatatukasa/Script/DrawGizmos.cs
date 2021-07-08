using UnityEditor;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    [SerializeField]
    private SphereCollider searchArea;
    Transform EnemyTransform;
    Vector3 EnemyPos;

    // 実際の索敵範囲とは異なり表示される円範囲の大きさです
    // 索敵範囲を絞るにはboltにある同名の変数を書き換えてください
    [SerializeField, Tooltip("実際の索敵範囲ではなく表示範囲の変数です。注意してください")]
    private float searchAngle = 100f;

    private void OnDrawGizmos()
    {
        EnemyTransform = transform;
        EnemyPos = EnemyTransform.position+Vector3.down;
        // ここでエラーが起こる
        //Handles.color = Color.red;
        //Handles.DrawSolidArc(EnemyPos, Vector3.up, Quaternion.Euler(0f, - searchAngle, 0f) * transform.forward, searchAngle * 2f, searchArea.radius);
    }
}
