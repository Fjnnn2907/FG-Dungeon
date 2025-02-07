using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : Entity
{
    #region State
    public PlayerStatMachine statMachine;
    public PlayerIdeState ideState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerGroundState groundState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerDeahState deahState { get; private set; }
    public PlayerShootState shootState { get; private set; }
    public PlayerRunShootState runShootState { get; private set; }
    public PlayerReloadState reloadState { get; private set; }
    public PlayerRunReloadState runReloadState { get; private set; }
    #endregion

    [Header("Setting Jump")]
    public float JumpForce = 10;
    [Header("Setting Attack")]
    public Vector2[] attackMovement;
    [Header("Setting Dash")]
    public float stamina;
    public float maxStamina;
    public int regenRate;
    [Header("Knock Back")]
    public Vector2 KnockDir = new Vector2(7, 12);
    public float KnockTimer = .07f;
    protected bool isKnocked;
    [Header("Bullet")]
    public int countBuletPistol = 24;
    public int countBulletSMG = 10;
    public int countBuletPistolBase {  get; private set; }
    public int countBulletSMGlBase { get; private set; }
    public enum WeaponType { Sword, Pistol, SMG }
    public WeaponType weaponType;
    [Header("UI")]
    public GameObject loseUI;
    protected override void Awake()
    {
        statMachine = new();
        ideState = new(this, statMachine, "Idle");
        moveState = new(this, statMachine, "Move");
        jumpState = new(this, statMachine, "Jump");
        airState = new(this, statMachine, "Jump");
        dashState = new(this, statMachine, "Dash");
        attackState = new(this, statMachine, "Attack");
        deahState = new(this, statMachine, "Deah");
        shootState = new(this, statMachine, "Shoot");
        runShootState = new(this, statMachine, "RunShoot");
        reloadState = new(this, statMachine, "ReLoad");
        runReloadState = new(this, statMachine, "RunReLoad");
    }

    protected override void Start()
    {
        base.Start();
        Time.timeScale = 1;
        statMachine.StartState(ideState);
        ReloadBullet();
    }

    private void ReloadBullet()
    {
        countBuletPistolBase = countBuletPistol;
        countBulletSMGlBase = countBulletSMG;
        stamina = maxStamina;
    }

    protected override void Update()
    {
        base.Update();
        statMachine.currentState.Update();

        Obsever.Notify("UpdateBullet");
        RegenerateStamina();

    }

    public void AminationTrigger() => statMachine.currentState.AminationTrigger();
    public void AddForce(float _x, float _y)
    {
        rb.AddForce(new Vector2(_x, _y));
    }


    public override void DamageEffect(Entity _entity, float _damage)
    {
        base.DamageEffect(_entity, _damage);

        StartCoroutine("KnockBack");
        
    }
    protected virtual IEnumerator KnockBack()
    {
        isKnocked = true;
        rb.velocity = new Vector2(KnockDir.x * -facing, KnockDir.y);
        yield return new WaitForSeconds(KnockTimer);
        isKnocked = false;
        SetZeroVelocity();
    }
    public void RegenerateStamina()
    {
        if (stamina < 100f)
        {
            stamina += regenRate * Time.deltaTime;
            stamina = Mathf.Min(stamina, maxStamina);
        }
    }
    public void EquipWeapon(WeaponType _weaponType)
    {
        weaponType = _weaponType;

        anim.SetLayerWeight(anim.GetLayerIndex("Pistol"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("Sword"), 0);
        anim.SetLayerWeight(anim.GetLayerIndex("SMG"), 0);

        switch (weaponType)
        {
            case WeaponType.Pistol:
                anim.SetLayerWeight(anim.GetLayerIndex("Pistol"), 1);
                break;
            case WeaponType.Sword:
                anim.SetLayerWeight(anim.GetLayerIndex("Sword"), 1);
                break;
            case WeaponType.SMG:
                anim.SetLayerWeight(anim.GetLayerIndex("SMG"), 1);
                break;
        }
    }
    
    public bool Weapon(WeaponType _weaponType)
    => weaponType == _weaponType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
            SceneManager.LoadScene("Boss");
    }

    protected override void IsDead()
    {
        base.IsDead();

        statMachine.ChangeState(deahState);
    }
}
