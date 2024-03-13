using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSpecial", menuName = "Enemy Logic/Attack Logic/BossSpecial")]
public class SpecterBossSpecial : EnemyAttackSOBase
{
    float SkullSpawned = 0, spawnTime = 0, SpawnRate = 0.5f;
    [SerializeField] public float Speed;
    private BossBase boss;

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
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        spawnTime += Time.deltaTime;

        if (boss.canSkill)
        {
            switch(boss.Type) 
            {
                case BossType.SkullBoss:
                    Summon();
                    break;
                case BossType.EyeBoss:
                    break;
                case BossType.SpiritBoss:
                    break;
                default: break;
            }
        }

        else if (!boss.canSkill)
        {
            boss.StateMachine.ChangeState(boss.MoveState2);
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

    void Summon()
    {
        if (spawnTime >= SpawnRate && SkullSpawned < 6)
        {
            spawnTime = 0f;
            GameManager.instance.eWaves.summoning = true;
            GameManager.instance.eWaves.Summon(6, enemy.transform.position, Quaternion.Euler(0, 0, (30 * SkullSpawned) + (-30)));
            SkullSpawned++;
            Debug.Log(SkullSpawned);
        }
        else if (SkullSpawned == 6)
        {
            boss.canSkill = false;
            GameManager.instance.eWaves.summoning = false;
            SkullSpawned = 0;
            int wave = GameManager.instance.eWaves.ResetEnemyCount();
        }
    }

    void Multiply()
    {

    }

}
