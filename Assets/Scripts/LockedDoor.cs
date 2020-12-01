using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] Animator doorAnimator;
    [SerializeField] Item keyNeeded;
    public Dialogue dialogue;

    private void Awake(){
//enqueue sentence with correct key type needed
        dialogue.sentences = new string[] {"I used the " + keyType + " key to open the door."};
    }

    public Key.KeyType GetKeyType(){
//return keytype needed for this door
        return keyType;
    }

    private void OnTriggerEnter(Collider col){
 //check if player has correct key type, unlock door if they do
        if(col.tag == "Player")
        {
            if (KeyHolder.instance.ContainsKey(this.GetKeyType()))
            {
                OpenDoor();
                KeyHolder.instance.RemoveKey(this.GetKeyType());
                Inventory.instance.RemoveItem(keyNeeded);
            }
            //else TODO insert locked door sound
        }
    }

    private void OpenDoor(){
//door open animation; dialogue triggered
        doorAnimator.SetBool("isOpen", true);
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
