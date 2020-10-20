using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    //[SerializeField] ItemDatabase database;

    //public int slotsX, slotsY;
    //public GUISkin skin;
    public List<Item> items = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory = false;
    private bool highlightBox = false;
    [SerializeField] GameObject invPanel;
    public int space = 15;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory found");
            return;
        }

        instance = this;
    }
    #endregion


    private void Start()
    {
        //add empties to inventory and slots
        //for (int i = 0; i < (slotsX * slotsY); i++)
        //{
        //    slots.Add(new Item());
        //    inventory.Add(new Item());
        //}

    }

    //inventory GUI
    //private void OnGUI()
    //{
    //    GUILayout.BeginArea(new Rect((Screen.width / 2) - 50, (Screen.height / 2), 500, 500));
    //    GUI.skin = skin;
  

    //    if (showInventory)
    //    {
    //        DrawInventory();
    //    }

    //    GUILayout.EndArea();
    //}

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            DrawInventory();
    }

    void DrawInventory()
    {
        Event ev = Event.current;
        int i = 0;


        invPanel.SetActive(!invPanel.activeInHierarchy);

        //for (int y = 0; y < slotsY; y++)
        //{
        //    for (int x = 0; x < slotsX; x++)
        //    {
                //Rect slotRect = new Rect(x * 105, y * 105, 100, 100);
                //GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                //slots[i] = inventory[i];

                //if(slots[i].itemName != null)
                //{
                    //GUI.DrawTexture(slotRect, slots[i].itemImage);

                    //if the mouse hovers over an item
                    //if (slotRect.Contains(ev.mousePosition))
                    //if canvas.Contains(mouse)
                    //{
                    //    HighlightItem();
                    //    highlightBox = true;

                    //    if(ev.button == 0)
                    //    {
                    //        Debug.Log("you clicked item");
                    //    }
                    //}

                    //else highlightBox = false;
                   
        //        }

        //        i++;
        //    }
        //}
    }

    void HighlightItem()
    {
        //change background of box?
        //highlight item with border
        //change mouse? player feedback
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        //find empty inv slot
        //for(int i = 0; i < inventory.Count; i++)
        //{
            //if(inventory[i].itemName == null)
            //{
                //look for the item in the database
                //for (int j = 0; j < database.items.Count; j++)
                //{
                  //  if (database.items[j].itemId == id);
                   // {
                     //   inventory[i] = database.items[id];
                    //}
                //}
               // break;
        //    }
        //}
    }

    void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        //for(int i = 0; i < inventory.Count; i++)
        //{
        //    if(inventory[i].itemId == id)
        //    {
        //        inventory[i] = new Item();
        //        break;
        //    }
        //}
    }

    //bool InventoryContains(int id)
    //{
    //    bool result = false;
    //    for (int i = 0; i < inventory.Count; i++)
    //    {
    //        result = inventory[i].itemId == id;
    //        if (result == true) break;
    //    }
    //    return result;
    //}


}
