using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Tutorial", menuName = "Item/Tutorial")]
public class TutorialComponent : ScriptableObject
{
    public int index;
    public string headerTutorial;
    [TextArea(15,20)]
    public string bodyTutorial;
    public Sprite imageTutorial;
}
