using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveUpDown", menuName = "Enemy Logic/Attack Logic/MoveUpDown")]
public class SpecterBoss : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    private BossBase boss;
    float timer = 0;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        boss = enemy.gameObject.GetComponent<BossBase>();
        if(enemy.transform.position.y > 0)
        enemy.MoveEnemy(Vector2.up * Speed);
        else
        enemy.MoveEnemy(Vector2.down * Speed);
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
        enemy.SetInPlaceStatus(false);
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        timer += Time.deltaTime;
        float spawnTime = 0;
        if (boss.CurrentHealth >= (boss.MaxHealth * 0.40f)) spawnTime = 10;
        else if (boss.CurrentHealth >= (boss.MaxHealth * 0.20f)) spawnTime = 8;
        else if (boss.CurrentHealth == (boss.MaxHealth * 0.10f)) spawnTime = 5;

        if (boss.CurrentHealth == (boss.MaxHealth * 0.50f) && !boss.canSkill)
        {
            boss.canSkill = true;
            timer = 0;
            enemy.StateMachine.ChangeState(boss.MoveState2);
        }

        else if ((boss.CurrentHealth < (boss.MaxHealth * 0.50f)) && (timer >= spawnTime) && !boss.canSkill)
        {
            boss.canSkill = true;
            Debug.Log(boss.canSkill.ToString());
            timer = 0;
            enemy.StateMachine.ChangeState(boss.MoveState2);
        }
        else Move();

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
    void Move()
    {
        if (enemy.transform.position.y > 3.5f)
        {
            boss.MoveEnemy(Vector2.down * Speed);
        }
        else if (boss.transform.position.y < -3.5f)
        {
            enemy.MoveEnemy(Vector2.up * Speed);
        }
    }
}

