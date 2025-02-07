public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = .3f;
        player.stamina -= 20;

        GameManager.instance.soundManager.PlaySoundEffect("Dash");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.facing * player.speed * 2, player.rb.velocity.y);

        if(startTimer < 0)
            stateMachine.ChangeState(player.ideState);
    }
}
