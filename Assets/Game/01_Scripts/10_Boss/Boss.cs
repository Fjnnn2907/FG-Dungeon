using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    #region Stats
    public BossIdleState idleState {  get; private set; }
    public BossSkill1State skill1State { get; private set; }
    public BossSkill2State skill2State { get; private set; }
    public BossDeadState deadState { get; private set; }
    #endregion
    [Header("Skill Info")]
    public float Skill1Cooldown;
    public float skill1Timer {  get; private set; }
    public float Skill2Cooldown;
    public float skill2Timer {  get; private set; }
    [Header("CheckPoint")]
    public Transform[] PointTele;
    private int previousTeleIndex = -1;
    public int countHit = 0;
    [Header("CheckSkill2")]
    public GameObject[] enemyFrefabs;
    public Transform pointSkill2;
    [Header("UI")]
    public GameObject uiWin;
    protected override void Awake()
    {
        base.Awake();

        idleState = new(this, this, statMachine, "Idle");
        skill1State = new(this, this, statMachine, "Skill1");
        skill2State = new(this, this, statMachine, "Skill2");
        deadState = new(this, this, statMachine, "Dead");
    }
    protected override void Start()
    {
        base.Start();

        statMachine.StartState(idleState);
    }
    protected override void Update()
    {
        base.Update();

        if (skill1Timer >= 0)
            skill1Timer -= Time.deltaTime;

        if (skill2Timer >= 0)
            skill2Timer -= Time.deltaTime;

    }

    public void TelePoint()
    {
        if (PointTele.Length > 0)
        {
            int randomIndex = Random.Range(0, PointTele.Length);

            if (randomIndex == previousTeleIndex)
                randomIndex = (randomIndex + 1) % PointTele.Length;

            Transform selectedPoint = PointTele[randomIndex];
            transform.position = selectedPoint.position;

            previousTeleIndex = randomIndex;

        }

    }

    public void InstantiateEnemy()
    {
        int randomIndex = Random.Range(0, enemyFrefabs.Length);

        var enemy =  Instantiate(enemyFrefabs[randomIndex], pointSkill2.position, Quaternion.identity);
        enemy.SetActive(true);
    }

    public void UseSkill1()
    {
        TelePoint();
        skill1Timer = Skill1Cooldown;
    }

    public void UseSkill2()
    {
        InstantiateEnemy();
        skill2Timer = Skill2Cooldown;
    }
    public override void DamageEffect(Entity _entity, float _damage)
    {
        base.DamageEffect(_entity, _damage);
        countHit++;
    }

    protected override void IsDead()
    {
        base.IsDead();

        statMachine.ChangeState(deadState);
    }
}
