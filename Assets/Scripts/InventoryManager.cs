using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemObject> ListFoodItem = new List<ItemObject>();
    public List<ItemObject> ListQuestionItem = new List<ItemObject>();

    public int selected;
    public Transform itemContent;
    public GameObject inventoryItem;
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
        foreach (var item in ListFoodItem)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            
        }
    }

    public void ShowListQuestionItem()
    {
        foreach(var item in ListQuestionItem)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
        }
    }
}
