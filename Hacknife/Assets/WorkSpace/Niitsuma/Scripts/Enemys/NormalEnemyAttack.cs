using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyPatrol))]
public class NormalEnemyAttack : BaseCharaAttack
{
    EnemyPatrol _patrol; //

    void Start()
    {
        _patrol = GetComponent<EnemyPatrol>();
    }

    public override void ApplyAttack()
    {
        Debug.Log("Attack");
    }

    void Update()
    {
        if (_patrol.IsFound)
        {
            ApplyAttack();
        }
    }
}
