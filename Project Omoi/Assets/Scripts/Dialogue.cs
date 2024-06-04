using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    // [TextArea(3, 10)]
    // public string[] sentences;

    [Header("Cutscenes")]
    public List<Cutscene> cutscenes = new List<Cutscene>();

    [System.Serializable]
    public class Cutscene
    {
        [Header("Cutscene")]
        public string name;
        [TextArea(3, 10)]
        public string[] sentences;
    }
}
