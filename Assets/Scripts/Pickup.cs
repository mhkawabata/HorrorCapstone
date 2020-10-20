using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //public Transform holdSpot;

    public Item item;
    public ParticleSystem particle;

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Pickup"))
            {
                particle.Play();
                Debug.Log("picking up " + item.name);
                Inventory.instance.AddItem(item);
                Destroy(gameObject);
            }
        }
    }

}
