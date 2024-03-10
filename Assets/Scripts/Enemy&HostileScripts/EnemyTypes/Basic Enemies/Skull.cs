using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : BaseEnemies
{
    public override void Attack()
    {
        EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[WaveNum - 1]);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
}
