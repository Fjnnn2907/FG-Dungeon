using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BulletUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI bulletText;

    [SerializeField] protected Sprite[] weaponImage;
    [SerializeField] protected Image iconWeapon;
    private void OnEnable()
    {
        Obsever.AddObsever("UpdateBullet", UpdateBullet);
    }
    private void OnDisable()
    {
        Obsever.RemoveObsever("UpdateBullet", UpdateBullet);
    }

    protected void UpdateBullet()
    {
        var player = GameManager.instance.playerManager.player;


        if (player.Weapon(Player.WeaponType.SMG))
        {
            bulletText.text = $"{player.countBulletSMG}<#72829c>/{player.countBulletSMGlBase}";
            iconWeapon.sprite = weaponImage[0];
        }
        else if (player.Weapon(Player.WeaponType.Pistol))
        {
            bulletText.text = $"{player.countBuletPistol}<#72829c>/{player.countBuletPistolBase}";
            iconWeapon.sprite = weaponImage[0];
        }
        else
        {
            bulletText.text = "Vo cuc";
            iconWeapon.sprite = weaponImage[1];
        }
       
    }
}
