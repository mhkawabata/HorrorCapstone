using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonMoveScript.instance.wasdMove = true;
        ThirdPersonMoveScript.instance.thirdMove = false;
    }
}
