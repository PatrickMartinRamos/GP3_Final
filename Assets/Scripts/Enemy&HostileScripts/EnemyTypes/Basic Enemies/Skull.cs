using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Enemy
{

    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
    }

    public override void Die()
    {
        ObjectPool.Release(this);
    }
}
