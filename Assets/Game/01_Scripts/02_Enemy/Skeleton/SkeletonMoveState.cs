using UnityEngine;

public class SkeletonMoveState : EnemyState
{
    private Skeleton skeleton;
    private Transform player;
    public SkeletonMoveState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
    {
        skeleton = _skeleton;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameManager.instance.playerManager.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        skeleton.SetVelocity(skeleton.speed * skeleton.facing,skeleton.rb.velocity.y);

        
        if (Vector2.Distance(skeleton.transform.position, player.position) < skeleton.battleDistance)
        {
            if (skeleton.IsCheckBattle())
                stateMachine.ChangeState(skeleton.reactState);
            else
            {
                if (Mathf.Abs(player.position.y - skeleton.transform.position.y) < .5)
                {
                    if (player.position.x < skeleton.transform.position.x)
                        skeleton.Flip();
                    else if (player.position.x > skeleton.transform.position.x)
                        skeleton.Flip();
                }                
            }      
        }


        if (!skeleton.IsGroundCheck() || skeleton.IsWallCheck())
            stateMachine.ChangeState(skeleton.idleState);
    }
}
