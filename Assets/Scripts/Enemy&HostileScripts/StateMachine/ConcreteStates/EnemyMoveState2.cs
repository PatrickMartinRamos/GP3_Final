using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState2 : EnemyState
{
    BossBase boss;
    public EnemyMoveState2(BossBase boss, EnemyStateMachine enemyStateMachine) : base(boss as Enemy, enemyStateMachine)
    {
        this.boss = boss;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        boss.EnemyMoveToPointInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        boss.Collider.enabled = false;
        boss.EnemyMoveToPointInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        boss.Collider.enabled = true;
        boss.EnemyMoveToPointInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        boss.EnemyMoveToPointInstance.DoFrameUpdateLogic();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        boss.EnemyMoveToPointInstance.DoPhysicsLogic();
    }
}
