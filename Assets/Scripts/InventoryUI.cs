using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    InventorySlot[] slots;

    void Start()
    {
        Inventory.instance.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < Inventory.instance.items.Count)
                slots[i].AddItem(Inventory.instance.items[i]);
            
            else
                slots[i].ClearSlot();
            
        }
    }
}
