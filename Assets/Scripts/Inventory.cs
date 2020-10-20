using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
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


    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
            DrawInventory();
    }

    void DrawInventory()
    {
        invPanel.SetActive(!invPanel.activeInHierarchy);
    }

    void HighlightItem()
    {
        //TODO
        //change background of box?
        //highlight item with border
        //change mouse? player feedback
    }

    public void AddItem(Item item)
    {
        items.Add(item);

        if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
      
    }

    void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        
    }

 


}
