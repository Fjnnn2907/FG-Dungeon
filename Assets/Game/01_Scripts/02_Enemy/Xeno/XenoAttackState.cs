using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoAttackState : EnemyState
{
    private Xeno xeno;
    public XenoAttackState(Enemy _enemy, Xeno _xeno, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        xeno = _xeno;
    }

    public override void Enter()
    {
        base.Enter();

        xeno.SetZeroVelocity();

        if (xeno.countCombo > xeno.maxCountCombo)
            xeno.countCombo = 0;

        xeno.anim.SetInteger("ComboCounter",xeno.countCombo);
    }

    public override void Exit()
    {
        base.Exit();

        xeno.countCombo++;
    }

    public override void Update()
    {
        base.Update();

        if (isTriggerCalled)
            stateMachine.ChangeState(xeno.battleState);
    }
}
