using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkill2State : EnemyState
{
    private Boss boss;
    public BossSkill2State(Enemy _enemy, Boss _boss, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        boss = _boss;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (isTriggerCalled)
        {
            boss.UseSkill2();
            stateMachine.ChangeState(boss.idleState);
        }
    }
}
