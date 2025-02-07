public class PlayerRunReloadState : PlayerState
{
    public PlayerRunReloadState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

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
            stateMachine.ChangeState(player.moveState); 

        player.SetVelocity(xInput * player.speed, player.rb.velocity.y);
    }
}
