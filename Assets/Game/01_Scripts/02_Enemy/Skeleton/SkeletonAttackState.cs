public class SkeletonAttackState : EnemyState
{
    private Skeleton skeleton;
    public SkeletonAttackState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        skeleton = _skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        skeleton.SetZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(isTriggerCalled)
            stateMachine.ChangeState(skeleton.battleState);
    }
}
