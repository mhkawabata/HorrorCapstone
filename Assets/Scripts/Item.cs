using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "new item";
    public string itemDescription;
    public int itemId;
    public Sprite itemImage = null;
    public ItemType itemType;

    public enum ItemType
    {
        Childhood,
        Teen,
        Adult,
        Key,
        Environment
    }

    public virtual void Use()
    {
        //use item
        Debug.Log("using " + name);
    }

    //public Item(string name, string desc, int id, ItemType type)
    //{
    //    itemName = name;
    //    itemDescription = desc;
    //    itemId = id;
    //    itemType = type;
    //    itemImage = Resources.Load<Sprite>("ItemIcons/" + name);
    //}

    //public Item()
    //{
        
    //}
}
