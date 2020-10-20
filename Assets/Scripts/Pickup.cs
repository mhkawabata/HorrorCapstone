using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform holdSpot;
    public ParticleSystem particle;

    private void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Pickup"))
            {
                particle.Play();
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                this.transform.position = holdSpot.position;
                this.transform.parent = GameObject.Find("ItemHoldSpot").transform;
            }
        }
    }

}
