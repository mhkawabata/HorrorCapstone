using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine {

    public class CameraControls : MonoBehaviour
    {
        public void CheckShot()
        {
            if (Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera.Description != null)
            {
                Debug.Log("camera type 1");
            }
    }
    }
}
