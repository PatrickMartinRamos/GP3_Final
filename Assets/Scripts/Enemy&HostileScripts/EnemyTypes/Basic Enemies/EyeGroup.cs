using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;

public class EyeGroup : BaseEnemies
{
    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
    }

    public override void Attack()
    {
        if (WaveNum <=2)
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[WaveNum - 1]);
        }
        else if(WaveNum == 3)
        {
            EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[EnemyID %2]);
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
