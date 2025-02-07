using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damage;
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            player.DamageEffect(player,damage);
        }
    }
}
