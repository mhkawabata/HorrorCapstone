using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    UI ui;
    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        ui = UI.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.Die();
        }
    }
}
