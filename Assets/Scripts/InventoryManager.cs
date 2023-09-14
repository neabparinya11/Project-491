using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemObject> ListFoodItem = new List<ItemObject>();
    public List<ItemObject> ListQuestionItem = new List<ItemObject>();

    public int selected;
    public Transform itemContent;
    public GameObject iconItem;
    public GameObject inventoryPanel;
    
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemObject _item)
    {
        if (_item.type == ItemType.Food)
        {
            ListFoodItem.Add(_item);
        }

        if (_item.type == ItemType.Question)
        {
            ListQuestionItem.Add(_item);
        }
    }

    public void RemoveItem(ItemObject _item)
    {
        if (_item.type == ItemType.Food)
        {
            ListFoodItem.Remove(_item);
        }

        if (_item.type == ItemType.Question)
        {
            ListQuestionItem.Remove(_item);
        }
    }

    public void ShowListFoodItem()
    {
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
    }

    public void ShowListQuestionItem()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in ListQuestionItem)
        {
            GameObject obj = Instantiate(iconItem, itemContent);
            var itemIcon = obj.transform.Find("Icon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventoryPanel.SetActive(true);
            ShowListFoodItem();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            inventoryPanel.SetActive(false);
        }
    }
}
