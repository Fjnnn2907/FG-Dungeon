using UnityEngine;

public class Xeno : Enemy
{
    public XenoIdleState idleState { get; private set; }
    public XenoMoveState moveState { get; private set; }
    public XenoAttackState attackState { get; private set; }
    public XenoBattleState battleState { get; private set; }
    public XenoDeadState deadState { get; private set; }

    [Header("Combo Attack")]
    public int countCombo = 0;
    public int maxCountCombo;

    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, statMachine, "Idle");
        moveState = new(this, this, statMachine, "Move");
        attackState = new(this, this, statMachine, "Attack");
        battleState = new(this, this, statMachine, "Move");
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
