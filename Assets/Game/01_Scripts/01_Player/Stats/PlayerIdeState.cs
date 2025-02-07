using UnityEngine;

public class PlayerIdeState : PlayerGroundState
{
    public PlayerIdeState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput != 0)
            stateMachine.ChangeState(player.moveState);

        //if (Input.GetKeyDown(KeyCode.J) && (player.Weapon(Player.WeaponType.Pistol) || player.Weapon(Player.WeaponType.SMG)))
        //    stateMachine.ChangeState(player.shootState);

        if (Input.GetKeyDown(KeyCode.R) && (player.Weapon(Player.WeaponType.Pistol) || player.Weapon(Player.WeaponType.SMG)))
            stateMachine.ChangeState(player.reloadState);

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (player.Weapon(Player.WeaponType.Pistol) && player.countBuletPistol > 0)
                stateMachine.ChangeState(player.shootState);
            else if(player.Weapon(Player.WeaponType.SMG) && player.countBulletSMG > 0)
                stateMachine.ChangeState(player.shootState);
        }
    }
}
