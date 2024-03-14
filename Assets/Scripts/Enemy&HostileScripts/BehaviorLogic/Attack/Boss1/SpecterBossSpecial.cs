using UnityEngine;
using DG.Tweening;
using System.Threading;

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
        enemy.SetInPlaceStatus(false);
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
                    LaserBeam();
                    break;
                case BossType.SpiritBoss:
                    Enlarge();
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
            GameManager.instance.eWaves.Summon(6, enemy.transform.position, Quaternion.Euler(0, 0,boss.transform.rotation.z));
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

    async void Enlarge()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(enemy.gameObject.GetComponent<SpriteRenderer>().DOFade(1f, 0.1f));
        seq.Join(enemy.gameObject.transform.DOScale(4f, 0.1f));
        seq.AppendInterval(2f);
        
        await seq.AsyncWaitForCompletion();
        enemy.gameObject.transform.DOScale(1.5f, 0.1f);
        boss.canSkill = false;
    }

    void LaserBeam()
    {
        boss.transform.GetChild(0).gameObject.SetActive(true);

        if (spawnTime > 2)
        {
            boss.transform.GetChild(0).gameObject.SetActive(false);
            spawnTime = 0;
            boss.canSkill = false;
        }

    }
}
