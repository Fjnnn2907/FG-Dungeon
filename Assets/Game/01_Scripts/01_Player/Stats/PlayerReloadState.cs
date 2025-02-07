using UnityEngine;

public class PlayerReloadState : PlayerAttackState
{
    public PlayerReloadState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();

        GameManager.instance.soundManager.PlaySoundEffect("Reload");
    }

    public override void Exit()
    {
        base.Exit();

        if (player.Weapon(Player.WeaponType.Pistol))
            player.countBuletPistol = player.countBuletPistolBase;

        if (player.Weapon(Player.WeaponType.SMG))
            player.countBulletSMG = player.countBulletSMGlBase;
    }

    public override void Update()
    {
        base.Update();

        if(isTriggerCalled)
            stateMachine.ChangeState(player.ideState);
    }
}
