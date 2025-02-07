public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
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

        if (player.IsGroundCheck())
            stateMachine.ChangeState(player.ideState);

        player.SetVelocity(xInput * player.speed * .65f, player.rb.velocity.y);
    }
}
