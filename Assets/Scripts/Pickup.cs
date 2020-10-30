using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Item item;
    public ParticleSystem particle;
    DialogueManager dialogueManager;
    public Dialogue dialogue;

    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Pickup"))
            {
                particle.Play();
                Debug.Log("picking up " + item.name);
                Inventory.instance.AddItem(item);
                dialogueManager.StartDialogue(dialogue);
                Destroy(gameObject);
            }
        }
    }

}
