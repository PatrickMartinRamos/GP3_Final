using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : Enemy
{
    public override void Awake()
    {
        base.Awake();
        MaxHealth *= 10;
    }
    public override void Attack()
    {
        base.Attack();
    }

    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
    }

    public override void Die()
    {
        base.Die();
    }

    public override void InitializeEnemy()
    {
        base.InitializeEnemy();
    }
}
