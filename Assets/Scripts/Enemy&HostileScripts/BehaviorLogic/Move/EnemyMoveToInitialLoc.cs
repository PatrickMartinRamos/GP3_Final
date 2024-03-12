using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartLocation
{
    None,
    Assign,
}

[CreateAssetMenu(fileName ="Move-Initial Location", menuName ="Enemy Logic/Move Logic/Move to Start")]
public class EnemyMoveToInitialLoc : EnemyMoveSOBase
{
    [SerializeField] float Speed = 2f;
    [SerializeField] StartLocation InitialPos;
    [SerializeField] Vector3 InitialLocation;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        switch (InitialPos)
        {
            case StartLocation.None:
                enemy.MoveEnemy(Vector2.left * Speed);
                break;
            case StartLocation.Assign:
                Vector3 direction = (InitialLocation - enemy.transform.position).normalized;
                enemy.MoveEnemy(direction * Speed);
                break;
            default: break;
        }

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
