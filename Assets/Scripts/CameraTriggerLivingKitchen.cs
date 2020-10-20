using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggerLivingKitchen : MonoBehaviour
{
    public GameObject living;
    public GameObject kitchen;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if (living.gameObject.activeInHierarchy == true)
            {
                living.gameObject.SetActive(false);
                kitchen.gameObject.SetActive(true);
            }

            else if (living.gameObject.activeInHierarchy == false)
            {
                kitchen.gameObject.SetActive(false);
                living.gameObject.SetActive(true);
            }
                
        }
    }


}
