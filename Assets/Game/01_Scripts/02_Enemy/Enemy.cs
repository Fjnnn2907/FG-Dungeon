using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public EnemyStateMachine statMachine;

    [Header("Wall Check")]
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallDistance;
    [Header("Battle Check")]
    public float battleTime;
    [SerializeField] protected Transform battleCheck;
    public float battleDistance;
    [SerializeField] protected LayerMask whatIsPlayer;
    [Header("Attack Info")]
    public float radiusAttack;
    [HideInInspector] public float lastTimeAttacked;
    public float attackCoolDown;
    [Header("Level info")]
    [SerializeField] protected int minLevel;
    [SerializeField] protected int maxLevel;
    public System.Action onFliped;
    protected override void Awake()
    {
        base.Awake();
        statMachine = new();
    }
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        statMachine.currentState.Update();
    }

    public override void Flip()
    {
        base.Flip();

        if(onFliped != null)
            onFliped();
    }

    public virtual int Level()
    {
        var currentLevel =  Random.Range(minLevel, maxLevel);
        
        for (int i = 0; i < currentLevel; i++)
        {
            maxHealth += 10;
        }
        return currentLevel;
    }

    public override void DamageEffect(Entity _entity, float _damage)
    {
        base.DamageEffect(_entity, _damage);
    }
    public virtual void AnimationTrigger() => statMachine.currentState.AminationTrigger();
    public virtual bool IsWallCheck()
    => Physics2D.Raycast(wallCheck.position, Vector2.right * facing, wallDistance, whatIsGround);

    public virtual RaycastHit2D IsCheckBattle()
    => Physics2D.Raycast(battleCheck.position, Vector2.right * facing, battleDistance, whatIsPlayer);



    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawRay(wallCheck.position, Vector3.right * facing * wallDistance);

        Gizmos.DrawRay(battleCheck.position, Vector3.right * facing * battleDistance);
    }
}
