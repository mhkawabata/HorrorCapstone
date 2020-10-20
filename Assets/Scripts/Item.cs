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
        //TODO use item. different use functionalities for different types
        Debug.Log("using " + name);
    }

}
