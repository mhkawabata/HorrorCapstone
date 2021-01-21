using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    //upon loading scene 1 for the first time,
    //play opening cutscene
    //player wakes up in bedroom
    /*
     * player introduced to mima
     * see lifestyle, work
     * prompted to walk to bathroom and brush teeth
     *      -introduce mechanics: walking, item pickup, show off camera angles
     * play second cutscene - phone call with boss, establish their relationship
     * 
     * 
     * interact with furniture - open things, sit on sofa or bed
     * time passes
     * cutscene - show entity
     * mima goes to bathroom and leaves phone on coffee table
     * something took photos of her in the bathroom
     * power goes out! turn on phone light
     */
    public PlayableDirector timeline;

    private void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    void PlayOpeningCutscene()
    {
        timeline.Play();
    }
}
