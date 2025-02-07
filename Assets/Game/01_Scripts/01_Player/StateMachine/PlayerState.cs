using UnityEngine;

public class PlayerState
{
    public PlayerStatMachine stateMachine;
    public Player player;

    protected string animBoolName;
    protected float startTimer;

    public bool isTriggerCalled;
    public float xInput { get; private set; }
    public PlayerState(Player _player, PlayerStatMachine _statMachine, string _animBoolName)
    {
        player = _player;
        stateMachine = _statMachine;
        animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        isTriggerCalled = false;
    }
    public virtual void Update()
    {
        startTimer -= Time.deltaTime;
        player.anim.SetFloat("yVelocity", player.rb.velocity.y);
        xInput = Input.GetAxisRaw("Horizontal");
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
        isTriggerCalled = true;
    }

    public void AminationTrigger()
    {
        isTriggerCalled = true;
    }
}
