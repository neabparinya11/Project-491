using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IDataPersistances
{
    public static InventoryManager Instance;
    public List<FoodItem> ListFoodItem = new List<FoodItem>();
    public List<QuestionItem> ListQuestionItem = new List<QuestionItem>();
    public List<TaskComponent> ListTask = new List<TaskComponent>();
    public List<TutorialComponent> ListTutorial = new List<TutorialComponent>();

    public int selected;
    [Header("Set continer item")]
    public Transform itemContent;
    public Transform taskContent;
    public GameObject itemContentObject;
    public GameObject taskContentObject;
    [Header("Set default item")]
    public GameObject iconItem;
    public GameObject iconQuest;
    public GameObject iconTask; // Use content task content
    public GameObject iconTutorial; // Use content task content
    [Header("Set detail panel")]
    public GameObject inventoryPanel;
    public GameObject itemDetailPanel;
    public GameObject itemQuestPanel;
    public GameObject itemTaskPanel;
    public GameObject itemTutorialPanel;
    
    public InventoryItemManager[] inventoryItem;
    public InventoryQuestManager[] inventoryQuest;
    public InventoryTaskManager[] inventoryTask;
    public InventoryTutorialManager[] inventoryTutorial;
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

    public void AddTaskList(TaskComponent _task)
    {
        ListTask.Add(_task);
    }

    public void SetCompleteTask(int index)
    {
        foreach (TaskComponent task in ListTask)
        {
            if (task.index == index)
            {
                task.isComplete = true;
            }
        }
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
        taskContentObject.SetActive(false);
        itemContentObject.SetActive(true);
        itemTaskPanel.SetActive(false);
        itemDetailPanel.SetActive(false);
        itemTutorialPanel.SetActive(false);
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in taskContent)
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

    public void ShowListTask()
    {
        itemContentObject.SetActive(false);
        taskContentObject.SetActive(true);
        itemTaskPanel.SetActive(false);
        itemDetailPanel.SetActive(false);
        itemTutorialPanel.SetActive(false);
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in taskContent)
        {
            Destroy(item.gameObject);
        }
        ListTask = ListTask.OrderByDescending(x => x.index).ToList();
        foreach (var task in ListTask)
        {
            GameObject obj = Instantiate(iconTask, taskContent);
            var head = obj.transform.Find("Task Header").GetComponent<TextMeshProUGUI>();
            head.SetText(!task.isComplete ? task.headTask : "<s>" + task.headTask + "</s>");
            var taskButton = obj.GetComponent<Button>();
            taskButton.interactable = !task.isComplete;
        }
        SetInventoryTask();
    }

    public void ShowListQuestionItem()
    {
        taskContentObject.SetActive(false);
        itemContentObject.SetActive(true);
        itemTaskPanel.SetActive(false);
        itemDetailPanel.SetActive(false);
        itemTutorialPanel.SetActive(false);
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in taskContent)
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

    public void ShowListTutorial()
    {
        itemContentObject.SetActive(false);
        taskContentObject.SetActive(true);

        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (Transform item in taskContent)
        {
            Destroy (item.gameObject);
        }
        foreach (var item in ListTutorial)
        {
            GameObject obj = Instantiate(iconTask, taskContent);

        }
        SetInventoryTutorial();
    }

    private void SetInventoryTutorial()
    {
        inventoryTutorial = taskContent.GetComponentsInChildren<InventoryTutorialManager>();
        for (int i = 0; i< ListTutorial.Count; i++)
        {
            inventoryTutorial[i].AddTutorial(ListTutorial[i]);
        }
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
            ClearDataList();
        }
    }

    public void ClearDataList()
    {
        foreach (Transform var in itemContent)
        {
            Destroy(var.gameObject);
        }

        foreach (Transform item in taskContent)
        {
            Destroy(item.gameObject);
        }
        itemDetailPanel?.SetActive(false);
        itemQuestPanel?.SetActive(false);
        itemTaskPanel?.SetActive(false);
        itemTutorialPanel?.SetActive(false);
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

    public void SetInventoryTask()
    {
        inventoryTask = taskContent.GetComponentsInChildren<InventoryTaskManager>();
        for (int i=0; i< ListTask.Count; i++)
        {
            inventoryTask[i].AddTask(ListTask[i]);
        }
    }
    public bool FindQuestItem(string itemName)
    {
        foreach (QuestionItem item in ListQuestionItem)
        {
            if (item.itemName.Equals(itemName))
            {
                return true;
            }
        }
        return false;
    }

    public bool FindListQuestItem(List<QuestionItem> findListQuestItem)
    {
        foreach (QuestionItem item in findListQuestItem)
        {
            if (!ListQuestionItem.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.listFoodItem = this.ListFoodItem;
        gameData.listQuestItem = this.ListQuestionItem;
        gameData.listTaskComponent = this.ListTask;
        //gameData.listFoodItem.Clear();
        //gameData.listQuestItem.Clear();
        //foreach (FoodItem itemData in this.ListFoodItem)
        //{
        //    gameData.listFoodItem.Add(itemData.itemName, itemData);
        //}
        //foreach (QuestionItem itemData in this.ListQuestionItem)
        //{
        //    gameData.listQuestItem.Add(itemData.itemName, itemData);
        //}
    }

    public void LoadData(GameData gameData)
    {
        this.ListFoodItem = gameData.listFoodItem;
        this.ListQuestionItem = gameData.listQuestItem;
        this.ListTask = gameData.listTaskComponent;
        //this.ListFoodItem.Clear();
        //this.ListQuestionItem.Clear();
        //foreach (SerialiazableDictionary<string, FoodItem> itemData in gameData.listFoodItem)
        //{
        //    this.ListFoodItem.Add(itemData.TryGetValue(itemData.Keys, out  ));
        //}
        //foreach (QuestionItem itemData in gameData.listQuestItem)
        //{
        //    this.ListQuestionItem.Add(itemData);
        //}
    }
}
