using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question Item", menuName = "Question Item System/Item/Question Item")]
public class QuestItemObject : ItemObject
{
    private void Awake()
    {
        type = ItemType.QuestItem;
    }
}
