using UnityEngine;

public class XenoTriggerAnimaton : MonoBehaviour
{
    private Xeno xeno;

    private void Awake()
    {
        xeno = GetComponentInParent<Xeno>();
    }

    public void AnimationTrigger() => xeno.AnimationTrigger();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.DamageEffect(player, xeno.damage);
        }
    }
}
