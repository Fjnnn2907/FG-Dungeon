using UnityEngine;

public class PlayerStatMachine
{
    public PlayerState currentState;

    public void StartState(PlayerState newState)
    {
        currentState = newState;
        currentState.Enter();
    }
    public void ChangeState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
