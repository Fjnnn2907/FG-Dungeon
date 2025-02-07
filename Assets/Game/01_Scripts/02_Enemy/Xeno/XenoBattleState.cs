using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoBattleState : EnemyState
{
    private Xeno xeno;

    private Transform player;
    public int moveDir;
    public XenoBattleState(Enemy _enemy, Xeno _xeno, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        xeno = _xeno;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameManager.instance.playerManager.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xeno.IsCheckBattle())
        {
            startTimer = xeno.battleTime;

            if (xeno.IsCheckBattle().distance <= xeno.radiusAttack)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(xeno.attackState);
                    return;
                }
                else
                    return;
            }
        }
        else
        {
            if (startTimer <= 0 || Vector2.Distance(xeno.transform.position, player.position) > 10)
                stateMachine.ChangeState(xeno.idleState);
        }

        if (player.position.x > xeno.transform.position.x)
            moveDir = 1;
        else if (player.position.x < xeno.transform.position.x)
            moveDir = -1;

        xeno.SetVelocity(xeno.speed * moveDir, xeno.rb.velocity.y);

    }

    private bool CanAttack()
    {
        if (Time.time >= xeno.lastTimeAttacked + xeno.attackCoolDown)
        {
            xeno.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}

    
