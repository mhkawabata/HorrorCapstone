using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public static ControlManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void OnRoomEnter()
    {
        StartCoroutine(ThirdPersonMoveScript.instance.EnterNewRoom());
    }
}
