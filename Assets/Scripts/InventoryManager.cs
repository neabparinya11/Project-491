using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemObject> Item = new List<ItemObject>();

    public Transform itemContent;
    public GameObject inventoryItem;
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemObject _item)
    {
        Item.Add(_item);
    }

    public void RemoveItem(ItemObject _item)
    {
        Item.Remove(_item);
    }

    public void ListItem()
    {
        foreach (var item in Item)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            //var itemIcon = obj.transform.Find().GetComponent<>();
        }
    }
}
