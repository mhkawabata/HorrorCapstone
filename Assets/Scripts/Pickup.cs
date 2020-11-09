using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    public ParticleSystem particle;
    DialogueTrigger dialogueTrigger;
    Key key;
    KeyHolder keyHolder;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();  
    }

    //private void OnTriggerStay(Collider col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        if (Input.GetButtonDown("Pickup"))
    //        {
    //            ItemPickup();
    //            Destroy(gameObject);
    //        }
    //    }
    //    else return;
    //}

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //if (Input.GetButtonDown("Pickup"))
            //{
                ItemPickup();
                Destroy(gameObject);
            //}
        }
        else return;
    }

    private void ItemPickup()
    {
    //play particle effect if any, trigger dialogue, add to inventory
        if (particle != null)particle.Play();

        if(dialogueTrigger != null)
            dialogueTrigger.TriggerDialogue();

        Inventory.instance.AddItem(item);

    //if it is a key, add to keyholder
        key = GetComponent<Key>();
        if (key != null)
        {
            KeyHolder.instance.AddKey(key.GetKeyType());
        }
        else return;
    }

}
