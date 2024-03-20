using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BossType
{
    SkullBoss,
    EyeBoss,
    SpiritBoss,
}
public class BossBase : Enemy
{
    public BossType Type;
    public EnemyMoveState2 MoveState2 { get; set; }
    public EnemyAttackState2 AttackState2 { get; set; }
    public EnemyMoveSOBase EnemyMoveToPointBase;
    public EnemyAttackSOBase HalfHPBossAtkBase;
    public EnemyMoveSOBase EnemyMoveToPointInstance { get; set; }
    public EnemyAttackSOBase HalfHPBossAtkInstance { get; set; }
    public bool canSkill { get; set; }
    public override void Awake()
    {
        base.Awake();
        string Name = this.gameObject.name;
        switch (Name)
        {
            case "SkullBoss(Clone)":
                Type = BossType.SkullBoss;
                break;
            case "EyeBoss(Clone)":
                Type = BossType.EyeBoss;
                break;
            case "SpiritBoss(Clone)":
                Type = BossType.SpiritBoss;
                break;
            default: break;
        }

        AttackState2 = new EnemyAttackState2(this, StateMachine);
        MoveState2 = new EnemyMoveState2(this, StateMachine);
        MaxHealth *= 10;
    }
    public override void Attack()
    {
        base.Attack();
        HalfHPBossAtkInstance = Instantiate(HalfHPBossAtkBase);
    }

    public override void Damage(float damageAmount)
    {
        base.Damage(damageAmount);
    }

    public override void Die()
    {
        base.Die();
        GameManager.instance.eWaves.roundNumber += 1;
    }

    public override void InitializeEnemy()
    {
        base.InitializeEnemy();

        EnemyMoveToPointInstance = Instantiate(EnemyMoveToPointBase);

        EnemyMoveToPointInstance.Initialize(gameObject, this);
        HalfHPBossAtkInstance.Initialize(gameObject, this);
    }

    public override void OnEnable()
    {
        base.OnEnable();
        canSkill = false;
    }
}
