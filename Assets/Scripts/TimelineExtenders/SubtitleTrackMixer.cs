using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //playerdata = object that our track is bound to. in this case, tmp ugui

        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;

        if (!text)
            return;

        int inputCount = playable.GetInputCount();
        for(int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);

            //tells us if we are working with active clip
            if(inputWeight > 0f)
            {
                ScriptPlayable<SubtitleBehavior> inputPlayable = (ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);

                SubtitleBehavior input = inputPlayable.GetBehaviour();
                currentText = input.subtitleText;
                currentAlpha = inputWeight;
            }
        }

        text.text = currentText;

        //allows fade in/out of text
        text.color = new Color(1, 1, 1, info.weight);

    }
}
