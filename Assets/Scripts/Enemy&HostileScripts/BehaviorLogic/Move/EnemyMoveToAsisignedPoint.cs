using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "MoveToDirected", menuName = "Enemy Logic/Move Logic/Directed Move")]
public class EnemyMoveToAssignedPoint : EnemyMoveSOBase
{
    [SerializeField] float Speed = 2f;
    [SerializeField] Vector3 direction;
    [SerializeField] float range;
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
        enemy.SetInPlaceStatus(true);

    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        BossBase boss = enemy.GetComponent<BossBase>();

        if (boss.Type == BossType.SpiritBoss)
            enemy.gameObject.GetComponent<SpriteRenderer>().DOFade(0.5f, 0.1f);

        if (boss.canSkill)
        {
            enemy.MoveEnemy(direction - initialLocation.normalized * Speed);
            if (Vector2.Distance(transform.position, initialLocation) >= range)
            {
                enemy.MoveEnemy(enemy.transform.position * 0);
                enemy.StateMachine.ChangeState(boss.AttackState2);
            }

        }

        else
        {
            enemy.MoveEnemy(Vector2.right * Speed);
            if (enemy.transform.position.x >= initialLocation.x+range)
            {
                enemy.MoveEnemy(enemy.transform.position * 0);
                enemy.gameObject.GetComponent<SpriteRenderer>().DOFade(0.5f, 0.1f);
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
