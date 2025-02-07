using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeRun : Trap
{
    [SerializeField] protected Transform wallCheck;
    [SerializeField] protected float wallDistance;
    [SerializeField] protected LayerMask whatIsGround;

    [SerializeField] protected float speed;
    [SerializeField] protected float facing = 1;
    protected void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * facing * Time.fixedDeltaTime);

        if (CheckWall())
        {
            facing *= -1;

            transform.localScale = new Vector3(facing * 
                Mathf.Abs(transform.localScale.x), 
                transform.localScale.y, 
                transform.localScale.z);
        }
    }

    protected bool CheckWall()
    => Physics2D.Raycast(wallCheck.position, Vector2.right * facing, wallDistance, whatIsGround);
    protected void OnDrawGizmos()
    {
            Gizmos.DrawLine(wallCheck.position, wallCheck.position + Vector3.right * facing * wallDistance);
    }
}
