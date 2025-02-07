using UnityEngine;
public class SkeletonBattleState : EnemyState
{
    private Skeleton skeleton;

    private Transform player;
    public int moveDir;
    public SkeletonBattleState(Enemy _enemy, Skeleton _skeleton, EnemyStateMachine _statMachine, string _animBoolName) : base(_enemy, _statMachine, _animBoolName)
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


        if (skeleton.IsCheckBattle())
        {
            startTimer = skeleton.battleTime;

            if (skeleton.IsCheckBattle().distance <= skeleton.radiusAttack)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(skeleton.attackState);
                    return;
                }
                else
                    return;
            }
        }
        else
        {
            if (startTimer <= 0 || Vector2.Distance(skeleton.transform.position, player.position) > 10)
                stateMachine.ChangeState(skeleton.idleState);
        }

        if (player.position.x > skeleton.transform.position.x)
            moveDir = 1;
        else if (player.position.x < skeleton.transform.position.x)
            moveDir = -1;

        skeleton.SetVelocity(skeleton.speed * moveDir, skeleton.rb.velocity.y);

    }

    private bool CanAttack()
    {
        if (Time.time >= skeleton.lastTimeAttacked + skeleton.attackCoolDown)
        {
            skeleton.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}
