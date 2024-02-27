using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckeable
{
    [SerializeableField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    [SerializeField] EnemyState eState;
    #region State Machine Variables
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyMovingState MoveState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    public bool isInPlace { get; set; }
    #endregion
    #region ScriptableObject Variable
    [SerializeField] private EnemyMoveSOBase EnemyMoveBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;
    public EnemyMoveSOBase EnemyMoveBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }

    #endregion
    #region Moving Variables
    public ObjectToPool poolCont;
    private Vector2 initialPos;
    #endregion
    void Awake() 
    {
        EnemyMoveBaseInstance = Instantiate(EnemyMoveBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);

        StateMachine = new EnemyStateMachine();

        MoveState = new EnemyMovingState(this,StateMachine);
        AttackState = new EnemyAttackState(this,StateMachine);

        initialPos = transform.position;
        poolCont = this.gameObject.GetComponent<ObjectToPool>();

    }
    void OnEnable()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();

        EnemyMoveBaseInstance.Initialize(gameObject, this);
        EnemyAttackBaseInstance.Initialize(gameObject, this);

        StateMachine.initialize(MoveState);
        eState = StateMachine.CurrentEnemyState;
    }
    void OnDisable()
    {
        transform.position = initialPos;
    }
    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
        Debug.Log(eState.ToString());
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }
    #region Health/Die Functions
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        
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