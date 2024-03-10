using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecterBoss Atk", menuName = "Enemy Logic/Attack Logic/SpecterBoss")]
public class SpecterBoss : EnemyAttackSOBase
{
    [SerializeField] public float Speed;
    float SkullSpawned = 0, spawnTime = 0, SpawnRate = 0.5f;
    bool canMove, canSkill;

    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType triggerType)
    {
        base.DoAnimationTriggerEventLogic(triggerType);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        canSkill = true;
        canMove = true;
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        spawnTime += Time.deltaTime;
        if (spawnTime > 5) { canSkill= true; }

        if (canMove) MoveUpDown();

        if(enemy.CurrentHealth <= (enemy.MaxHealth * 0.80) && canSkill)
        {
            SpecialSkill();
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
    private void MoveUpDown()
    {
        if (enemy.transform.position.y > 3.5f)
        {
            enemy.MoveEnemy(Vector2.down * Speed);
        }
        else if (enemy.transform.position.y < -3.5f)
        {
            enemy.MoveEnemy(Vector2.up * Speed);
        }
    }
    private void SpecialSkill()
    {
        canSkill= false;
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, new Vector2(3, 0),0.3f);
        canMove = false;

        Summon();
    }
    //Skull SP Skill
    public void Summon()
    {
        if (spawnTime >= SpawnRate && SkullSpawned < 6)
        {
            spawnTime = 0f;
            GameManager.instance.eWaves.Summon(6,enemy.transform.position, Quaternion.Euler(0, 0, -60 * SkullSpawned));
            SkullSpawned++;
        }
        else if(SkullSpawned==6)canMove= true;
    }
}

