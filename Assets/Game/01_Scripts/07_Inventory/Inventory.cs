using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<InventoryItem> invetory;
    public Dictionary<ItemData, InventoryItem> inventoryDic;

    public List<ItemData> startItem = new();

    [Header("Inventory UI")]
    [SerializeField] private Transform inventorySlots;
    private ItemSlot[] itemSlot;


    private void Start()
    {
        invetory = new List<InventoryItem>();
        inventoryDic = new Dictionary<ItemData, InventoryItem>();

        itemSlot = inventorySlots.GetComponentsInChildren<ItemSlot>();

        for (int i = 0; i < startItem.Count; i++)
        {
            AddItem(startItem[i]);
        }
    }

    public void AddItem(ItemData _item)
    {
        if (inventoryDic.TryGetValue(_item, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(_item);
            invetory.Add(newItem);
            inventoryDic.Add(_item, newItem);
        }
        UpdateSlotUI();
        Obsever.Notify("Quest");
    }

    public void RemoveItem(ItemData _item)
    {
        if (inventoryDic.TryGetValue(_item, out InventoryItem value))
        {
            if (value.stackSize <= 1)
            {
                invetory.Remove(value);
                inventoryDic.Remove(_item);
            }
            else
                value.RemoveStack();
           
        }

        //if (stashDir.TryGetValue(_item, out InventoryItem stashValue))
        //{
        //    if (stashValue.stackSize <= 1)
        //    {
        //        stash.Remove(stashValue);
        //        stashDir.Remove(_item);
        //    }
        //    else
        //        stashValue.RemoveStack();
        //}

        Obsever.Notify("Quest");
        UpdateSlotUI();
    }
    public bool CheckItem(ItemData item, int requiredAmount)
    {
        if (inventoryDic.TryGetValue(item, out InventoryItem value))
        {
            return value.stackSize >= requiredAmount;
        }
        return false;
    }

    private void UpdateSlotUI()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].CleanSlot();
        }
                                            
        for (int i = 0; i < invetory.Count; i++)
        {
            itemSlot[i].UpdateSlot(invetory[i]);
        }
    }
}
