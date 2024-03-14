using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Move-Assigned Point", menuName = "Enemy Logic/Move Logic/Move to Point")]
public class EnemyMoveToAssignedPoint : EnemyMoveSOBase
{
    [SerializeField] float Speed = 2f;
    [SerializeField] Vector3 targetLocation;
    Vector3 initialLocation;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        initialLocation = enemy.transform.position;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        BossBase boss = enemy.GetComponent<BossBase>();
        if (boss.canSkill)
        {
            enemy.MoveEnemy(targetLocation - initialLocation.normalized * Speed);
            if (Vector2.Distance(transform.position, initialLocation) >= 3f)
            {
                enemy.MoveEnemy(enemy.transform.position * 0);
                enemy.StateMachine.ChangeState(boss.AttackState2);
            }

        }

        else
        {
            enemy.MoveEnemy(Vector2.right * Speed);
            if (enemy.transform.position.x >= initialLocation.x+3)
            {
                enemy.MoveEnemy(enemy.transform.position * 0);
                enemy.StateMachine.ChangeState(boss.AttackState);
            }
        }

    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }


    public override void ResetValues()
    {
        base.ResetValues();
    }
}
