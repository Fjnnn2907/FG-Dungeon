using UnityEngine;

public class SkeletonTrigger : MonoBehaviour
{
    private Skeleton skeleton;

    private void Awake()
    {
        skeleton = GetComponentInParent<Skeleton>();
    }

    public void AnimationTrigger() => skeleton.AnimationTrigger();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.DamageEffect(player,skeleton.damage);
        }
    }
}
