using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : EnemyState
{
    private Boss boss;

    private Transform player;
    public BossIdleState(Enemy _enemy, Boss _boss, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        boss = _boss;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameManager.instance.playerManager.player.transform;

        if (player.position.x < boss.transform.position.x)
            boss.Flip();
        else if (player.position.x > boss.transform.position.x)
            boss.Flip();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        
        if(boss.IsCheckBattle() && boss.skill2Timer < 0)
        {
            stateMachine.ChangeState(boss.skill2State);
            return;
        }

        if (boss.IsCheckBattle() && boss.skill1Timer < 0 || boss.countHit > 3)
        {
            stateMachine.ChangeState(boss.skill1State);
            boss.countHit = 0;
        }

    }
}

