using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, PlayerStatMachine _statMachine, string _animBoolName) : base(_player, _statMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space) && player.IsGroundCheck())
            stateMachine.ChangeState(player.jumpState);

        if(!player.IsGroundCheck())
            stateMachine.ChangeState(player.airState);

        if (Input.GetKeyDown(KeyCode.L) && player.IsGroundCheck() && player.stamina >= 20)
            stateMachine.ChangeState(player.dashState);

        if (Input.GetKeyDown(KeyCode.J) && player.IsGroundCheck() && player.weaponType == Player.WeaponType.Sword)
            stateMachine.ChangeState(player.attackState);

        if (Input.GetKeyDown(KeyCode.Alpha2) && player.IsGroundCheck())
        {
            player.EquipWeapon(Player.WeaponType.Pistol);
            stateMachine.ChangeState(player.ideState);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && player.IsGroundCheck())
        {
            player.EquipWeapon(Player.WeaponType.Sword);
            stateMachine.ChangeState(player.ideState);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && player.IsGroundCheck())
        {
            player.EquipWeapon(Player.WeaponType.SMG);
            stateMachine.ChangeState(player.ideState);
        }
    }
}