using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossBase : Enemy
{
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
        AttackState2 = new EnemyAttackState2(this, StateMachine);
        MoveState2 = new EnemyMoveState2(this, StateMachine);
        MaxHealth *= 10;
        canSkill= false;
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
    }

    public override void InitializeEnemy()
    {
        base.InitializeEnemy();

        EnemyMoveToPointInstance = Instantiate(EnemyMoveToPointBase);

        EnemyMoveToPointInstance.Initialize(gameObject, this);
        HalfHPBossAtkInstance.Initialize(gameObject, this);
    }

}
