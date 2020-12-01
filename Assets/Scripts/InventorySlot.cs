using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    GameObject player;

    //spherecast vars
    private Vector3 origin;
    private float sphereRadius = 6f;
    private Vector3 direction;
    private float maxDistance = 6f;
    private LayerMask layerMask;
    public GameObject currentHitObj;
    private bool foundHit = false;
    Lamp lamp;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        layerMask = LayerMask.GetMask("Lamps");
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemImage;
        icon.enabled = true;
        GetComponentInChildren<Button>().interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        GetComponentInChildren<Button>().interactable = false;
    }

    public void UseItem()
    {
        //check if item exists & is usable
        if (item != null && item.isUsableHere == true)
        {
            //if lightbulb, use light. else use normally
            if (item.name == "lightbulb")
            {
                foundHit = false;
                origin = player.transform.position;
                direction = player.transform.forward;
                RaycastHit hit;

                //layerMask, QueryTriggerInteraction.UseGlobal

                //spherecast to check for nearby lamps
                foundHit = (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.Collide));
                    if(foundHit)
                {
                    //if(hit.collider.gameObject != null)
                    Debug.Log("hit " + hit);
                    //currentHitObj = hit.transform.gameObject;
                    //if (currentHitObj.GetComponent<Lamp>() != null)
                    //Debug.Log("got lamp comp");
                    //lamp = currentHitLamp.GetComponent<Lamp>();
                    //lamp.UseLightbulb();
                }
                else Debug.Log("no hit");
                //currentHitObject = hit.transform.gameObject;
                //lamp.UseLightbulb();
            }
            else item.Use(item);
        }
        else Debug.Log("cant use here");
            
    }


    public void ShowDescription()
    {
        if(item != null)
        ItemDescriptions.ShowDescription_Static(item.itemDescription);
    }

    public void HideDescription()
    {
        ItemDescriptions.HideDescription_Static();
    }    
}
