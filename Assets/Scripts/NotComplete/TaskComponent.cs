using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Task item", menuName = "Item/Task item")]
public class TaskComponent: ScriptableObject
{
    public int index;
    public string headTask; 
    [TextArea(15,20)]
    public string descriptionTask;
    public bool isComplete = false;
}
