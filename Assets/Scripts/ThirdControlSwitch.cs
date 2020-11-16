using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdControlSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ThirdPersonMoveScript.instance.wasdMove = false;
        ThirdPersonMoveScript.instance.thirdMove = true;
    }
}
