using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject entry;
    public GameObject living;

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if (entry.gameObject.activeInHierarchy == true)
            {
                entry.gameObject.SetActive(false);
                living.gameObject.SetActive(true);
            }

            else if (entry.gameObject.activeInHierarchy == false)
            {
                living.gameObject.SetActive(false);
                entry.gameObject.SetActive(true);
            }
                
        }
    }


}
