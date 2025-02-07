public class SkeletonReactState : EnemyState
{
    private Skeleton skeleton;
    public SkeletonReactState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        skeleton = _skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        startTimer = .4f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(startTimer < 0)
            stateMachine.ChangeState(skeleton.battleState);
    }
}
