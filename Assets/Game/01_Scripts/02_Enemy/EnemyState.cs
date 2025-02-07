using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public EnemyStateMachine stateMachine;
    public Enemy enemy;

    protected string animBoolName;
    protected float startTimer;

    public bool isTriggerCalled;
    public float xInput { get; private set; }
    public EnemyState(Enemy _enemy, EnemyStateMachine _statMachine, string _animBoolName)
    {
        enemy = _enemy;
        stateMachine = _statMachine;
        animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        enemy.anim.SetBool(animBoolName, true);
        isTriggerCalled = false;
    }
    public virtual void Update()
    {
        startTimer -= Time.deltaTime;
    }
    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);
        isTriggerCalled = true;
    }

    public void AminationTrigger()
    {
        isTriggerCalled = true;
    }
}
