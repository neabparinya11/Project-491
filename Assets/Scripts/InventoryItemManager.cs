using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemManager : MonoBehaviour
{
    ItemObject item;

    //public GameObject healthManager;
    public void RemoveItem()
    {
        InventoryManager.Instance.RemoveItem(item);
        Destroy(gameObject);
    }

    public void AddNewItem(ItemObject _item)
    {
        item = _item;
    }
    public void UseItem()
    {
        switch (item.type)
        {
            case ItemType.Food:
                Debug.Log("Food");
                break;
            case ItemType.Question:

                break;
            default:
                break;
        }
        RemoveItem();
    }
}
