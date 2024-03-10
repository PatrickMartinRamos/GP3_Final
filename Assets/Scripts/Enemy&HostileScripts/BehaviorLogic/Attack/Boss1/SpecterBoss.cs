using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAtk - Move Forward", menuName = "Enemy Logic/Attack Logic/SpecterBoss")]
public class SpecterBoss : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    public yPosType ChooseType;
    [SerializeField][Range(-5, 5)] float yPos;
    private Vector3 targetPos;
    private Vector3 direction;
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

        enemy.transform.position = new Vector2(enemy.transform.position.x,Mathf.Lerp(-4, 4, Mathf.PingPong(Time.time, 1)));
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

