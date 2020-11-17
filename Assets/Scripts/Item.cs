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

    public void Use(Item item)
    {
        //TODO use item. different use functionalities for different types
        Inventory.instance.RemoveItem(item);
        Debug.Log("using " + name);
    }

}
