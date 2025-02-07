using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 dir;
    private float speed;
    private float lifeTime = 5f;
    private float lifeTimer;
    private float damage;
    private ObjectPool pool;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetUpSword(Vector2 _dir, float _speed, ObjectPool _pool, float _damage)
    {
        dir = _dir.normalized;
        speed = _speed;
        pool = _pool;
        lifeTimer = lifeTime;
        damage = _damage;
    }

    private void FixedUpdate()
    {
        MoveBullet();
        HandleLifeTime();
    }

    private void MoveBullet()
    {
        rb.velocity = dir * speed * Time.fixedDeltaTime;
    }

    private void HandleLifeTime()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            ReturnToPool();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();           
            if (enemy != null)
            {
                enemy.DamageEffect(enemy, damage);
            }

            ReturnToPool();
        
    }

    private void ReturnToPool()
    {
        rb.velocity = Vector2.zero;
        pool.ReturnObject(gameObject);
    }
}
