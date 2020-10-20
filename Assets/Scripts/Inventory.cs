using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] ItemDatabase database;
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory = false;
    private bool highlightBox = false;
    

    private void Start()
    {
        //add empties to inventory and slots
        for (int i = 0; i < (slotsX * slotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }

    }

    //inventory GUI
    private void OnGUI()
    {
        GUI.skin = skin;

        if (showInventory)
        {
            DrawInventory();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    void DrawInventory()
    {
        Event ev = Event.current;
        int i = 0;

        for (int y = 0; y < slotsY; y++)
        {
            for (int x = 0; x < slotsX; x++)
            {
                Rect slotRect = new Rect(x * 120, y * 120, 100, 100);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];

                if(slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemImage);

                    if (slotRect.Contains(ev.mousePosition))
                    {
                        HighlightItem();
                        highlightBox = true;

                        if(ev.button == 0)
                        {
                            Debug.Log("you clicked item");
                        }
                    }

                    else highlightBox = false;
                   
                }

                i++;
            }
        }
    }

    void HighlightItem()
    {
        //change background of box?
        //highlight item with border
        //change mouse? player feedback
    }

    public void AddItem(int id)
    {
        //find empty inv slot
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].itemName == null)
            {
                //look for the item in the database
                for (int j = 0; j < database.items.Count; j++)
                {
                    if (database.items[j].itemId == id);
                    {
                        inventory[i] = database.items[id];
                    }
                }
                break;
            }
        }
    }

    void RemoveItem(int id)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].itemId == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemId == id;
            if (result == true) break;
        }
        return result;
    }


}
