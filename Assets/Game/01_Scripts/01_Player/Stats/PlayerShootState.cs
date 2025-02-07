using UnityEngine;

public class PlayerShootState : PlayerState
{
    public PlayerShootState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();

        if (player.Weapon(Player.WeaponType.Pistol))
            player.countBuletPistol--;

        if(player.Weapon(Player.WeaponType.SMG))
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
            stateMachine.ChangeState(player.ideState);
    }
}
