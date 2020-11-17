using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] Item lightbulb;
    [SerializeField] GameObject bulbSpot;
    [SerializeField] GameObject lightBulbPrefab;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Inventory.instance.items.Contains(lightbulb))
            {
                if (bulbSpot != null)
                {
                    lightBulbPrefab.transform.parent = bulbSpot.transform;
                    Debug.Log("used lightbulb");
                }
            }

            else Debug.Log("no lightbulb");
          
            //if player presses 'use' on lightbulb
            //remove bulb from inventory
            //parent bulb to the bulbSpot
            //turn on the light component

           //lightbulb = GetComponent<>
            
        }
    }
}
