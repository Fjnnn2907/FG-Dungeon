using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoDeadState : EnemyState
{
    private Xeno xeno;
    public XenoDeadState(Enemy _enemy, Xeno _xeno, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        xeno = _xeno;
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = 3;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (startTimer <= 0)
            xeno.gameObject.SetActive(false);
    }
}
