using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//creatable class in unity. embedded in dialogueTrigger script for objects with dialogue on them
public class Dialogue 
{
    [TextArea(2, 10)]
    public string[] sentences;
}
