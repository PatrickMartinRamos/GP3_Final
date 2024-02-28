using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyAtk - Move Forward", menuName ="Enemy Logic/Attack Logic/Move Forward")]
public class EnemyAttackMoveForward : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    [SerializeField][Range(-5f, 5f)] public float yPos;
    private Vector3 targetPos;
    private Vector3 direction;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
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
        CheckIfOutsideViewport();
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
    private void CheckIfOutsideViewport()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // If the bullet is outside the viewport, set it false
        if (viewportPos.x < -0 || viewportPos.x > 2 || viewportPos.y < -2 || viewportPos.y > 2)
        {
            enemy.Die();
        }
    }
}
