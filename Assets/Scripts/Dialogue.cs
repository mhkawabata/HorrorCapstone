using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    //uncomment name var if you want name of speaker to show
    //public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
