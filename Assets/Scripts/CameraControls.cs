using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cinemachine {

    public class CameraControls : MonoBehaviour  //ICinemachineCamera
    {
        //trigger a function on eery camera cut event to check which control scheme to use
        //check the name of the currently live child of CM ClearShot cam
        //make a bool for WASD controls
        //livingAerial, kitchenCam, kitchenOvenCam, balconyCam, bedroomCam use regular controls
        //entry, bedClose, tvCam, kitchenClose, bathroomCam use WASD controls

        [SerializeField] GameObject cameraParent;
        ICinemachineCamera liveChildCam;
        ICinemachineCamera[] cameraArray;
        List<ICinemachineCamera> cameraList1 = new List<ICinemachineCamera>();
        List<ICinemachineCamera> cameraList2 = new List<ICinemachineCamera>();



        private void Start()
        {
            cameraArray = cameraParent.GetComponentsInChildren<ICinemachineCamera>();

            foreach (ICinemachineCamera camera in cameraArray)
            {
                //add livingAerial, kitchenCam, kitchenOvenCam, balconyCam, bedroomCam to List1
                if (camera.VirtualCameraGameObject.CompareTag("camAngle1"))
                    cameraList1.Add(camera);

                //add entry, bedClose, tvCam, kitchenClose, bathroomCam to List2
                else if (camera.VirtualCameraGameObject.CompareTag("camAngle2"))
                    cameraList2.Add(camera);
            }
        }
        public void CheckShot()
        {
            bool camFound = false;
            //get name of current active child camera. search list for cam with same name.
          


            //while(camFound == false)
            //{
            //    //if currently active cam is in list 1 use controls 1
            //    for (int i = 0; i < cameraList1.Count; i++)
            //    {
            //        if (cameraList1[i].Name.Contains(cameraName))
            //        {
            //            ThirdPersonMoveScript.instance.wasdMove = false;
            //            Debug.Log(cameraName);
            //            camFound = true;
            //        }        
            //    }

            //    //if it is in list 2 use controls 2
            //    for(int j = 0; j < cameraList2.Count; j++)
            //    {
            //        if (cameraList2[j].Name.Contains(cameraName))
            //        {
            //            ThirdPersonMoveScript.instance.wasdMove = true;
            //            Debug.Log(cameraName);
            //            camFound = true;
            //        }
            //    }
            //}
        }
    
    }
}
