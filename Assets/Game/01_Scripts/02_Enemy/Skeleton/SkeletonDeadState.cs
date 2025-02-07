using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : EnemyState
{
    private Skeleton skeleton;
    public SkeletonDeadState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        skeleton = _skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = 3;
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.gameObject.SetActive(false);
    }

    public override void Update()
    {
        base.Update();

        if(startTimer <= 0)
            skeleton.gameObject.SetActive(false);
    }
}
