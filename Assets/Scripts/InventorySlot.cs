using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    GameObject player;
    public Dialogue dialogue;

    //spherecast vars
    private float sphereRadius = 1f;
    private LayerMask layerMask;
    public GameObject currentHitObj;
    Lamp lamp;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        layerMask = LayerMask.GetMask("Lamps");
        dialogue.sentences = new string[] { "I can't use that here.." };
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
            //if lightbulb, check if there is a lamp in range to plug it into
            if (item.name == "lightbulb")
            {
                Collider[] hitColliders = Physics.OverlapSphere(player.transform.position, sphereRadius, layerMask, QueryTriggerInteraction.Ignore);
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject != null)
                    {
                        lamp = hitCollider.gameObject.GetComponent<Lamp>();
                        lamp.UseLightbulb();
                    }
                    else return;
                }
            }
            else
            {
                item.Use(item);
                Debug.Log("using non lightbulb");
            }
        }
        //if it cant be used here, pop up dialogue
        else
        {
            DialogueManager.instance.StartDialogue(dialogue);
            Debug.Log("canbt use here");
        }
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
