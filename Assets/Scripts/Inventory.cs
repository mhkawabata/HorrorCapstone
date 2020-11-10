using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<Item> slots = new List<Item>();
    //private bool showInventory = false;
    //private bool highlightBox = false;
    [SerializeField] GameObject invPanel = null;
    public int space = 15;

    public delegate void OnItemChangedDelegate();
    public OnItemChangedDelegate onItemChangedCallback;

    InventoryUI inventoryUI;

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
        //onItemChangedCallback += InventoryUI.instance.UpdateUI;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            invPanel.SetActive(!invPanel.activeInHierarchy);
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback();

    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        
    }

    void HighlightItem()
    {
        //TODO
        //change background of box?
        //highlight item with border
        //change mouse? player feedback
    }



}
