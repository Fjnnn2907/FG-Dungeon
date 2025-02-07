using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
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

        if(xInput == 0)
            stateMachine.ChangeState(player.ideState);

        player.SetVelocity(xInput * player.speed, player.rb.velocity.y);

        //if(Input.GetKeyDown(KeyCode.J) && (player.Weapon(Player.WeaponType.Pistol) || player.Weapon(Player.WeaponType.SMG)))
        //    stateMachine.ChangeState(player.runShootState);

        if (Input.GetKeyDown(KeyCode.R) && (player.Weapon(Player.WeaponType.Pistol) || player.Weapon(Player.WeaponType.SMG)))
            stateMachine.ChangeState(player.runReloadState);

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (player.Weapon(Player.WeaponType.Pistol) && player.countBuletPistol > 0)
                stateMachine.ChangeState(player.shootState);
            else if (player.Weapon(Player.WeaponType.SMG) && player.countBulletSMG > 0)
                stateMachine.ChangeState(player.shootState);
        }

    }
}