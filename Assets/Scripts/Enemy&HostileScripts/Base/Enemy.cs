using System;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckeable
{

    public float MaxHealth { get; set; } = 50f;
    [field: SerializeField] public float CurrentHealth { get; set; }
    public IObjectPool<Enemy> ObjectPool { get; set; }
    public Rigidbody2D rb { get; set; }

    #region State Machine Variables
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyMovingState MoveState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public bool isInPlace { get; set; }
    #endregion

    #region ScriptableObject Variable
    [SerializeField] private EnemyMoveSOBase EnemyMoveBase;
    public List<EnemyAttackSOBase> EnemyAttackSOBaseList;
    public int WaveNum { get; set; } = 1;
    public int EnemyID { get; set; } = 1;
    /*    private EnemyAttackSOBase EnemyAttackBase;*/
    public EnemyMoveSOBase EnemyMoveBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }
    #endregion

    #region Moving Variables
    private Vector2 initialPos;
    #endregion
    public virtual void Awake() 
    {

        initialPos = transform.position;

        StateMachine = new EnemyStateMachine();
        MoveState = new EnemyMovingState(this, StateMachine);

    }
    public virtual void OnEnable()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();

        Attack();

        EnemyMoveBaseInstance = Instantiate(EnemyMoveBase);

        InitializeEnemy();
    }
    void OnDisable()
    {
        transform.position = initialPos;
    }
    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public virtual void InitializeEnemy()
    {
        EnemyMoveBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.initialize(MoveState);
    }

    #region Attack Function
    public virtual void Attack()
    {
        EnemyAttackBaseInstance = Instantiate(EnemyAttackSOBaseList[0]);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
    #endregion

    #region Health/Die Functions
    public virtual void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        this.gameObject.SetActive(false);
    }
    #endregion

    #region Movement Functions
    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
    }
    #endregion

    #region Location Checker
    public void SetInPlaceStatus(bool IsInPlace)
    {
        isInPlace = IsInPlace;
    }
    #endregion

    #region Animation Triggers
    public void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayfootstepSound,
    }
    #endregion
}