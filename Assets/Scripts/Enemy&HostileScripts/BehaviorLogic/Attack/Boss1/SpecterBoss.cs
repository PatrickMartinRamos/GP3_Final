using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "MoveUpDown", menuName = "Enemy Logic/Attack Logic/MoveUpDown")]
public class SpecterBoss : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    private BossBase boss;
    float timer = 0;
    float spawnTime = 0;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        boss = enemy.gameObject.GetComponent<BossBase>();
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

        if (enemy.isInPlace)
        {
            enemy.gameObject.GetComponent<SpriteRenderer>().DOFade(1f, 0.1f);
            enemy.MoveEnemy(Vector2.up * Speed);
            enemy.SetInPlaceStatus(false);
        }

        if (boss.CurrentHealth <= (boss.MaxHealth * 0.80f)) spawnTime = 6;
        else if (boss.CurrentHealth <= (boss.MaxHealth * 0.30f)) spawnTime = 4;
        else if (boss.CurrentHealth <= (boss.MaxHealth * 0.10f)) spawnTime = 2;

        if (boss.CurrentHealth == (boss.MaxHealth * 0.50f))
        {
            boss.canSkill = true;
            timer = 0;
            enemy.StateMachine.ChangeState(boss.MoveState2);
        }

        else if ((boss.CurrentHealth < (boss.MaxHealth * 0.50f)) && (timer >= spawnTime))
        {
            boss.canSkill = true;
            timer = 0;
            enemy.StateMachine.ChangeState(boss.MoveState2);
        }
        //Move Up Down if can't skill
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

