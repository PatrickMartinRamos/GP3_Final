using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : Enemy
{
    private void Awake()
    {
        MaxHealth *= 10;
    }
    public override void Die()
    {
        base.Die();
    }
}
