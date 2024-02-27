using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Move-Initial Location", menuName ="Enemy Logic/Move Logic/Move to Start")]
public class EnemyMoveToInitialLoc : EnemyMoveSOBase
{
    [SerializeField] public float Speed = 2f;
    private Vector3 targetPos;
    private Vector3 direction;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        targetPos = new Vector2(7.5f, enemy.transform.position.y);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        direction = (targetPos - enemy.transform.position).normalized;
        enemy.MoveEnemy(direction * Speed);
        if(Vector2.Distance(enemy.transform.position, targetPos) <= 0.3f)
        {
            enemy.SetInPlaceStatus(true);
        }
        else
            enemy.SetInPlaceStatus(false);
    }

    public override void DoPhysicsLogic()
    {
        base.DoPhysicsLogic();
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
