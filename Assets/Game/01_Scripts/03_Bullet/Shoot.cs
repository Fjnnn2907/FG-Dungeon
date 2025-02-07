using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform firePoint; 
    public float bulletSpeed = 500;

    private Player player => gameObject.GetComponentInParent<Player>();
    public void Shooting()
    {
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = Quaternion.identity;

        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.SetUpSword(new Vector2(player.facing,0), bulletSpeed * 2, bulletPool,player.damage);
        bulletController.transform.localScale = new Vector3(player.facing,1,1);
        GameManager.instance.soundManager.PlaySoundEffect("SMG");
    }
}
