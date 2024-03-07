using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdType : BaseEnemies
{
    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
    }

    public override void Attack()
    {
        float rand;
        if (WaveNum == 1)
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[WaveNum - 1]);
        }
        else if (WaveNum == 2)
        {
            rand = Random.value;
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[rand < 0.5f ? 0 : 1]);
        }
        else if (WaveNum == 3)
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[Random.Range(0, 3)]);
        }
        AttackState = new EnemyAttackState(this, StateMachine);
    }

    public override void InitializeEnemy()
    {
        EnemyMoveBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.initialize(AttackState);
    }
}
