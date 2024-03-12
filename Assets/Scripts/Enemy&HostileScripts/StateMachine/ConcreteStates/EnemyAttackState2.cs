using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState2 : EnemyState
{
    BossBase boss;
    public EnemyAttackState2(BossBase boss, EnemyStateMachine enemyStateMachine) : base(boss as Enemy, enemyStateMachine)
    {
        this.boss = boss;
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
        boss.HalfHPBossAtkInstance.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        boss.HalfHPBossAtkInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        boss.HalfHPBossAtkInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        boss.HalfHPBossAtkInstance.DoFrameUpdateLogic();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        boss.HalfHPBossAtkInstance.DoPhysicsLogic();
    }
}
