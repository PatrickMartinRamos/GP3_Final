using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum yPosType
{
    Random,
    Unchanged,
    Modified,
}

[CreateAssetMenu(fileName ="EnemyAtk - Move Forward", menuName ="Enemy Logic/Attack Logic/Move Forward")]
public class EnemyAttackMoveForward : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    public yPosType ChooseType;
    [SerializeField] [Range(-5,5)]float yPos;
    private Vector3 targetPos;
    private Vector3 direction;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        switch (ChooseType)
        {
            case yPosType.Random:
                yPos = Random.Range(-5, 5);
                break;
            case yPosType.Unchanged:
                yPos = enemy.transform.position.y;
                break;
            case yPosType.Modified:
                break;
            default: break;
        }
        targetPos = new Vector2(-10, yPos);
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
