using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Qustion item", menuName = "Item/Question item")]
public class QuestionItem : ItemObject
{
    public int index;
    private void Awake()
    {
        type = ItemType.Question;
    }

    public int GetIndex()
    {
        return index;
    }
}
