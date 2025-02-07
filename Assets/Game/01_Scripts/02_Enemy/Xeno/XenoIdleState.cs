using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoIdleState : EnemyState
{
    private Xeno xeno;
    public XenoIdleState(Enemy _enemy, Xeno _xeno, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        xeno = _xeno;
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = Random.Range(.5f, 1.5f);

        xeno.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (startTimer < 0)
        {
            stateMachine.ChangeState(xeno.moveState);
            xeno.Flip();
        }
    }
}
