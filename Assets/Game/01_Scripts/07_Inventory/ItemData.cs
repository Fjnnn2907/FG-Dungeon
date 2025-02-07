using UnityEngine;

[CreateAssetMenu(fileName = "new ItemData", menuName = "Data/Item")]
public class ItemData : ScriptableObject
{
    public enum ItemType { Coint,Diamond,Item, Flask }
    public ItemType Itemtype;
    public string itemiD;
    public string itemName;
    public Sprite icon;
    
    [ContextMenu("Test Drop")]
    private void RandomItemID()
    {
        itemiD = Random.Range(0, 9999).ToString();
    }
}

