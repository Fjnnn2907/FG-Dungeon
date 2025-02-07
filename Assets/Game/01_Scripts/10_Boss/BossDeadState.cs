using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadState : EnemyState
{
    private Boss boss;
    public BossDeadState(Enemy _enemy, Boss _boss, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        boss = _boss;
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

        if(startTimer < 0)
            boss.uiWin.SetActive(true);
    }
}
