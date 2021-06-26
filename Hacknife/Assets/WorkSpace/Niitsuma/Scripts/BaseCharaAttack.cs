using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharaAttack : MonoBehaviour, IAttackable
{
    [SerializeField] protected int atk;

    public virtual void ApplyAttack() { }
}
