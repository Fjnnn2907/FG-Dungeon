public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.AddForce(player.rb.velocity.x,player.JumpForce);
        //player.SetVelocity(player.rb.velocity.x, player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.rb.velocity.y <= 0)
            stateMachine.ChangeState(player.airState);

        player.SetVelocity(xInput * player.speed * .65f, player.rb.velocity.y);
    }
}
