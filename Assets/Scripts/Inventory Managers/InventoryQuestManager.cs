using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryQuestManager : MonoBehaviour
{
    QuestionItem quest;
    
    public void RemoveQuestItem()
    {
        InventoryManager.Instance.RemoveQuestionItem(quest);
        Destroy(gameObject);
    }

    public void AddQuestionItem(QuestionItem _item)
    {
        quest = _item;
    }

    public void QuestionDetails()
    {
        QuestionItemDetail.instance.ClearAllDetail();

        QuestionItemDetail.instance.questItemName = quest.itemName;
        QuestionItemDetail.instance.questItemDetail = quest.description;
        QuestionItemDetail.instance.SetActivate(true);
    }
}
