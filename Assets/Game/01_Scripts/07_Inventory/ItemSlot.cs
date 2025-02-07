using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    [SerializeField] protected Image itemIcon;
    [SerializeField] protected TextMeshProUGUI itemText;
    [SerializeField] protected Image count;
    [SerializeField] protected Image focus;
    [SerializeField] protected InventoryItem item;

    public void UpdateSlot(InventoryItem _newItem)
    {
        item = _newItem;
        itemIcon.color = Color.white;

        if (item != null)
        {
            itemIcon.sprite = item.itemData.icon;
            if (item.stackSize > 1)
            {
                itemText.text = item.stackSize.ToString();
                count.gameObject.SetActive(true);
            }
            else
            {
                itemText.text = "";
            }
        }
    }

    public void CleanSlot()
    {
        item = null;

        itemIcon.sprite = null;
        itemIcon.color = Color.clear;
        itemText.text = "";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        focus.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        focus.gameObject.SetActive(false);
    }
}
