using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCut : MonoBehaviour
{
    //[SerializeField] float waitTime = 5;
    float timer = 2f;
    public void OnCut()
    {
        //StartCoroutine(CutWait());
        //timer -= Time.deltaTime;
        //if (timer <= 0)
            Debug.Log("cut");
    }

    //IEnumerator CutWait()
    //{
        //timer += Time.deltaTime;
        //if(timer >= waitTime)
        //Debug.Log("cut");
        //return;
        //yield return new WaitForSeconds(5);
    //}
}
