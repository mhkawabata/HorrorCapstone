using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControls : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ThirdPersonMoveScript.instance.wasdMove = true;
            ThirdPersonMoveScript.instance.thirdMove = false;
            ThirdPersonMoveScript.instance.fourthMove = false;
        }
        
    }
}
