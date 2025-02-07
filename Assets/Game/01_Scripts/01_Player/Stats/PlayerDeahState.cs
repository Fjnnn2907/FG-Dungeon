using UnityEngine;

public class PlayerDeahState : PlayerState
{
    public PlayerDeahState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = 1;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (startTimer < 0)
        {
            Time.timeScale = 0;
            player.loseUI.SetActive(true);
        }
    }
}
