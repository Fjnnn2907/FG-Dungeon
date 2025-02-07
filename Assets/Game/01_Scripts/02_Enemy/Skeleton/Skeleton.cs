using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public SkeletonIdleState idleState {  get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonAttackState attackState { get; private set; }
    public SkeletonBattleState battleState { get; private set; }
    public SkeletonReactState reactState { get; private set; }
    public SkeletonDeadState deadState { get; private set; }
    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, statMachine, "Idle");
        moveState = new(this, this, statMachine, "Move");
        attackState = new(this, this, statMachine, "Attack");
        battleState = new(this, this, statMachine, "Move");
        reactState = new(this, this, statMachine, "React");
        deadState = new(this, this, statMachine, "Deah");
    }
    protected override void Start()
    {
        base.Start();

        statMachine.StartState(idleState);
    }

    protected override void IsDead()
    {
        base.IsDead();

        statMachine.ChangeState(deadState);
    }
}
