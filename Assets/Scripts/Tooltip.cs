using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private bool mouseOver = false;
    InventorySlot slot;

    private void Awake()
    {
        slot = GetComponentInParent<InventorySlot>();
    }

    private void Update()
    {
        if (mouseOver)
        {
            slot.ShowDescription();
        }

        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
            mouseOver = true;
            slot.ShowDescription();
        
        
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
        ItemDescriptions.HideDescription_Static();

    }
}
