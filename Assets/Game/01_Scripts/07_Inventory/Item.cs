using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 velocity;

    public void SetUpItem(Vector2 _velocity)
    {
        rb.velocity = _velocity;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            if (itemData.Itemtype == ItemData.ItemType.Coint)
                GameManager.instance.cointManager.AddCoint(100);
            else if (itemData.Itemtype == ItemData.ItemType.Diamond)
                GameManager.instance.cointManager.AddDiamond(100);
            else if (itemData.Itemtype == ItemData.ItemType.Item)
                GameManager.instance.inventoryManager.AddItem(itemData);
            else if (itemData.Itemtype == ItemData.ItemType.Flask)
                GameManager.instance.playerManager.player.AddHealth(10);
            
            gameObject.SetActive(false);
        }
    }
}
