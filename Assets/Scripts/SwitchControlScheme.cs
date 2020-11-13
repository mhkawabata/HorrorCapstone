using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControlScheme : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonMoveScript.instance.wasdMove = false;
    }
}
