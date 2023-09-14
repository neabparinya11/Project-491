using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Qustion item", menuName = "Item/Question item")]
public class QuestionItem : ItemObject
{
    [SerializeField] int index;
    private void Awake()
    {
        type = ItemType.Question;
    }
}
