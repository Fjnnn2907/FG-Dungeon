using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XenoMoveState : EnemyState
{
    private Xeno xeno;

    private Transform player;
    public XenoMoveState(Enemy _enemy, Xeno _xeno, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
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

        xeno.SetVelocity(xeno.speed * xeno.facing, xeno.rb.velocity.y);


        if (!xeno.IsGroundCheck() || xeno.IsWallCheck())
        {
            stateMachine.ChangeState(xeno.idleState);
            return;
        }

        if (Vector2.Distance(xeno.transform.position, player.position) < xeno.battleDistance)
        {
            if (xeno.IsCheckBattle())
            {
                stateMachine.ChangeState(xeno.battleState);
            }
            else
            {
                if (Mathf.Abs(player.position.y - xeno.transform.position.y) < .5) // 0.5f là khoảng chấp nhận được
                {
                    if (player.position.x < xeno.transform.position.x)
                        xeno.Flip();
                    else if (player.position.x > xeno.transform.position.x)
                        xeno.Flip();
                }
            }
        }



    }
}
