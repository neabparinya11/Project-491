using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchItem : MonoBehaviour
{
    public FoodItem item;
    public List<FoodItem> ListAllFoodItem;

   public void PickupItem()
    {
        item = ListAllFoodItem[UnityEngine.Random.Range(0, ListAllFoodItem.Count)];
        InventoryManager.Instance.AddFoodItem(item);
    }

}
