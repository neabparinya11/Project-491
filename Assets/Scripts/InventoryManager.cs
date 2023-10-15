using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<FoodItem> ListFoodItem = new List<FoodItem>();
    public List<QuestionItem> ListQuestionItem = new List<QuestionItem>();

    public int selected;
    public Transform itemContent;
    public GameObject iconItem;
    public GameObject iconQuest;
    public GameObject inventoryPanel;
    public GameObject itemDetailPanel;
    public GameObject itemQuestPanel;
    
    public InventoryItemManager[] inventoryItem;
    public InventoryQuestManager[] inventoryQuest;
    private void Awake()
    {
        Instance = this;
    }

    public void AddFoodItem(FoodItem _item)
    {
        ListFoodItem.Add(_item);
    }

    public void AddQuestionItem(QuestionItem _item)
    {
        ListQuestionItem.Add(_item);
    }

    public void RemoveFoodItem(FoodItem _item)
    {
        ListFoodItem.Remove(_item);
    }

    public void RemoveQuestionItem(QuestionItem _item)
    {
        ListQuestionItem.Remove(_item);
    }

    public void ShowListFoodItem()
    {
        itemDetailPanel.SetActive(false);
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ListFoodItem)
        {
            GameObject obj = Instantiate(iconItem, itemContent);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
        SetInventoryItem();
    }

    public void ShowListQuestionItem()
    {
        itemDetailPanel.SetActive(false);
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ListQuestionItem)
        {
            GameObject obj = Instantiate(iconQuest, itemContent);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
        SetInventoryQuest();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(true);
            ShowListFoodItem();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inventoryPanel.SetActive(false);
        }
    }

    public void SetInventoryItem()
    {
        inventoryItem = itemContent.GetComponentsInChildren<InventoryItemManager>();
        for (int i = 0; i< ListFoodItem.Count; i++)
        {
            inventoryItem[i].AddNewItem(ListFoodItem[i]);
        }
    }

    public void SetInventoryQuest()
    {
        inventoryQuest = itemContent.GetComponentsInChildren<InventoryQuestManager>();
        for (int i = 0; i< ListQuestionItem.Count; i++)
        {
            inventoryQuest[i].AddQuestionItem(ListQuestionItem[i]);
        }
    }
}
