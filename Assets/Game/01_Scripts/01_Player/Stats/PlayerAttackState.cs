using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerAttackState : PlayerState
{
    private int comboCounter;

    private float lastimeAttacked;
    private int comboWindow = 2;
    public PlayerAttackState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //player.rb.gravityScale = 60;

        if (comboCounter >= 4 || Time.time >= lastimeAttacked + comboWindow)
            comboCounter = 0;

        player.anim.SetInteger("ComboCounter", comboCounter);

        if (player.attackMovement[comboCounter].x != 0)
        {
            player.SetVelocity(player.attackMovement[comboCounter].x * player.facing, player.rb.velocity.y);
        }
        else
        {
            player.SetZeroVelocity();
            player.rb.gravityScale = 60;
        }

        
        //player.SetVelocity(player.attackMovement[comboCounter].x *
        //player.facing, player.rb.velocity.y);

        GameManager.instance.soundManager.PlaySoundEffect("Hit");
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        lastimeAttacked = Time.time;

        player.rb.gravityScale = 3.5f;
    }

    public override void Update()
    {
        base.Update();

        if (isTriggerCalled)
            stateMachine.ChangeState(player.ideState);
    }
}
