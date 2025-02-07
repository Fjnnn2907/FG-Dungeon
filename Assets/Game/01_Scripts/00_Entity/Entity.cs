using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Compoment
    public Rigidbody2D rb { get; private set; }
    public Animator anim {  get; private set; }
    public EntityFX fx { get; private set; }
    public SpriteRenderer sr { get; private set; }
    #endregion
    #region Stats
    [Header("Stat Info")]
    private float health;
    public float maxHealth;
    public float damage;
    [Header("Setting Move")]
    public float speed = 10;
    protected bool isRight = true;
    public int facing { get; private set; } = 1;
    [Header("Check Ground")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected Vector2 boxSize;
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask whatIsGround;
    #endregion

    protected bool isDeah;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        fx = GetComponent<EntityFX>();
        sr = GetComponentInChildren<SpriteRenderer>();

        health = maxHealth;
    }
    protected virtual void Update()
    {
        Obsever.Notify("UpdateHealth");
    }

    public virtual void DamageEffect(Entity _entity, float _damage)
    {
        if(health <= 0) return;

        fx.StartCoroutine("HitFlashFx");

        _entity.health -= _damage;

        if(health <= 0 && !isDeah)
        {
            IsDead();
            isDeah = true;
        }

    }

    public virtual float TakeHealth() => health;
    public virtual void AddHealth(float _health)
    {
        if(health >= maxHealth) return;

        health += _health;

        Obsever.Notify("UpdateHealth");
    }
    public virtual bool IsGroundCheck() => Physics2D.BoxCast(groundCheck.position, boxSize, 0f, Vector2.down, groundCheckDistance, whatIsGround);
    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position + Vector3.down * groundCheckDistance / 2, boxSize);
    }
    protected virtual void IsDead()
    {
    }

    #region Velocity
    public virtual void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.velocity = new Vector2(xVelocity, yVelocity);

        FlipCtrl(xVelocity);
    }
    public virtual void SetZeroVelocity()
    {
        rb.velocity = new Vector2(0, 0);
    }
    #endregion
    #region Flip
    public virtual void Flip()
    {
        facing *= -1;
        isRight = !isRight;
        transform.Rotate(0, 180, 0);
    }
    public void FlipCtrl(float x)
    {
        if (x > 0 && !isRight) Flip();
        else if (x < 0 && isRight) Flip();
    }
    #endregion
}
