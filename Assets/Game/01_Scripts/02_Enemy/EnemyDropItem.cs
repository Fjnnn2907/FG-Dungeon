using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    public List<ItemDrop> Items;

    public void DropItem()
    {
        if (Items == null || Items.Count == 0)
            return;

        float totalRate = 0f;
        foreach (var item in Items)
        {
            totalRate += item.Rate;
        }

        float randomValue = Random.Range(0f, totalRate);
        float cumulativeRate = 0f;

        foreach (var item in Items)
        {
            cumulativeRate += item.Rate;
            if (randomValue <= cumulativeRate)
            {
                var newItem = Instantiate(item.Item, transform.position, Quaternion.identity);

                Vector2 randomVelocity = new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 7f));
                newItem.GetComponent<Item>().SetUpItem(randomVelocity);
                return;
            }
        }
    }

    [ContextMenu("Test Drop")]
    private void TestDrop()
    {
        DropItem();
    }
}

[System.Serializable]
public class ItemDrop
{
    public GameObject Item;
    [Range(0f, 1f)]
    public float Rate;
}
