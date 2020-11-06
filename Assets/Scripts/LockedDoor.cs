using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    [SerializeField] Animator doorAnimator;
    [SerializeField] Item keyNeeded;

    public Key.KeyType GetKeyType(){
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
            else Debug.Log("dont have the right key");
        }
    }

    private void OpenDoor(){
//play door opening animation
        doorAnimator.SetBool("isOpen", true);
    }
}
