using UnityEngine;

public class PlayerRunShootState : PlayerState
{
    public PlayerRunShootState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (player.Weapon(Player.WeaponType.Pistol))
            player.countBuletPistol--;

        if (player.Weapon(Player.WeaponType.SMG))
            player.countBulletSMG--;

    }

    public override void Exit()
    {
        base.Exit();

        
    }

    public override void Update()
    {
        base.Update();

        if (isTriggerCalled)
            stateMachine.ChangeState(player.moveState);

        if (xInput == 0)
            stateMachine.ChangeState(player.ideState);  

        player.SetVelocity(xInput * player.speed, player.rb.velocity.y);

        
    }
}
