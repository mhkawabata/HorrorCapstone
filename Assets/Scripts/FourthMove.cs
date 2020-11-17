using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthMove : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ThirdPersonMoveScript.instance.wasdMove = false;
            ThirdPersonMoveScript.instance.thirdMove = false;
            ThirdPersonMoveScript.instance.fourthMove = true;
        }
        
    }
}
