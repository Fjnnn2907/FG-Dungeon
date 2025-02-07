using Cainos.PixelArtPlatformer_Dungeon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTriggerAnim : MonoBehaviour
{
    private Player player => gameObject.GetComponentInParent<Player>();

    public void TriggerAnimation() => player.AminationTrigger();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        var door = collision.gameObject.GetComponent<Switch>();
        var chest = collision.gameObject.GetComponent<Chest>();
        
        if (enemy != null)
            enemy.DamageEffect(enemy,player.damage);

        if(door != null && !door.IsOn)
        {
            GameManager.instance.soundManager.PlaySoundEffect("Switch");
            door.TurnOn();
        }

        if(chest != null && !chest.IsOpened)
        {
            GameManager.instance.soundManager.PlaySoundEffect("OpenChest");
            chest.Open();
        }
    }
}
