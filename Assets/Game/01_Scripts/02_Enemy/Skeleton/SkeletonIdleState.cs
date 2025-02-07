using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    private Skeleton skeleton;
    public SkeletonIdleState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        skeleton = _skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = Random.Range(.5f, 1.5f);

        skeleton.SetZeroVelocity();
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
            stateMachine.ChangeState(skeleton.moveState);
            skeleton.Flip();
        }
    }
}
