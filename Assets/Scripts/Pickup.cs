using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform holdSpot;
    public ParticleSystem particle;
    [SerializeField] Inventory invScript;

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Pickup"))
            {
                particle.Play();

                invScript.AddItem(0);
                this.gameObject.SetActive(false);
            }
        }
    }

}
