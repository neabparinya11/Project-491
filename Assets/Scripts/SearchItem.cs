using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : MonoBehaviour
{
    public ItemObject item;
    public List<ItemObject> ListAllFoodItem;

   public void PickupItem()
    {
        item = ListAllFoodItem[UnityEngine.Random.Range(0, ListAllFoodItem.Count)];
        InventoryManager.Instance.AddItem(item);
    }

}
