using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : BaseEnemies
{
    public override void Attack()
    {
        if(WaveNum == 0)
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[WaveNum]);
        }
        else
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[WaveNum - 1]);
        }
        AttackState = new EnemyAttackState(this, StateMachine);
    }
}
