using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public string itemDescription;
    public int itemId;
    public Texture itemImage;
    public ItemType itemType;

    public enum ItemType
    {
        Childhood,
        Teen,
        Adult,
        Key,
        Environment
    }

    public Item(string name, string desc, int id, ItemType type)
    {
        itemName = name;
        itemDescription = desc;
        itemId = id;
        itemType = type;
        itemImage = Resources.Load<Texture>("ItemIcons/" + name);
    }

    public Item()
    {
        
    }
}
