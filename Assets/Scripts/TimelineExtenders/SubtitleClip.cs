using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    //set text in editor
    public string subtitleText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SubtitleBehavior>.Create(graph);

        //get subtitles from the playable object and set subtitle text from that
        SubtitleBehavior subtitleBehaviour = playable.GetBehaviour();
        subtitleBehaviour.subtitleText = subtitleText;

        return playable;
    }
}
