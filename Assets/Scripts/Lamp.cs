using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
  //Lightbulbs are only usable when in range of a lamp.

    [SerializeField] Item lightbulb;
    [SerializeField] GameObject bulbSpot;
    [SerializeField] GameObject lightBulbPrefab;

    private void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){

            if (Inventory.instance.items.Contains(lightbulb))
            {
                int count = 0;
                foreach (Item itemsInList in Inventory.instance.items){
                    if (Inventory.instance.items[count].name == "lightbulb")
                    {
                        Inventory.instance.items[count].isUsableHere = true;
                        Debug.Log(Inventory.instance.items[count] + " active");
                    }
                     
                    count++;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player"){

            if (Inventory.instance.items.Contains(lightbulb))
            {
                int count = 0;
                foreach (Item itemsInList in Inventory.instance.items)
                {
                    if (Inventory.instance.items[count].name == "lightbulb")
                    {
                        Inventory.instance.items[count].isUsableHere = false;
                        Debug.Log(Inventory.instance.items[count] + " not active");
                    }
                        
                    count++;
                }
            }
        }   
    }

    public void UseLightbulb()
    {
        if (bulbSpot != null)
        {
            GameObject bulb = Instantiate(lightBulbPrefab, bulbSpot.transform.position, Quaternion.identity);
            Light light = bulb.GetComponentInChildren<Light>();
            light.enabled = true;
            Inventory.instance.RemoveItem(lightbulb);
        }
    }
}
