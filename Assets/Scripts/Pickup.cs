using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    public ParticleSystem particle;
    DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
        
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Pickup"))
            {
                particle.Play();
                Debug.Log("picking up " + item.name);
                dialogueTrigger.TriggerDialogue();
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

}
