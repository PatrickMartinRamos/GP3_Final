using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemies : Enemy
{
    public override void Die()
    {
        ObjectPool.Release(this);
    }
}
