using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] points; // 目的地を格納する配列
    private int destPoint = 0; // 目的地の数
    private NavMeshAgent agent; // エージェント

    void GotoNextPoint()
    {
        // 地点が何も設定されていないと返す
        if (points.Length == 0)
        {
            return;
        }

        // エージェントが設定された目標地点へ移動するようにする
        agent.destination = points[destPoint].position;

        // 配列内の次の位置を目標地点に設定する
        // 必要であれば出発地点に戻る
        destPoint = (destPoint + 1) % points.Length;
    }

    void Start()
    {
        agent = transform.root.GetComponent<NavMeshAgent>();

        // autobreakingをfalseにすると、目標地点の間を継続的に移動するようになる
        // エージェントは目標地点に近づいても速度を落とさず移動し続ける
        agent.autoBraking = false;
    }

    void Update()
    {
        // エージェントが現在の目標地点に近づいてきたら次の目標地点を設定
        if(!agent.pathPending&&agent.remainingDistance<0.5f)
        {
            GotoNextPoint();
        }
    }
}
