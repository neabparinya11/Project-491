using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemManager : MonoBehaviour
{
    FoodItem item;

    public void RemoveItem()
    {
        InventoryManager.Instance.RemoveFoodItem(item);
        Destroy(gameObject);
    }

    public void AddNewItem(FoodItem _item)
    {
        item = _item;
    }
    public void UseItem()
    {
        switch (item.type)
        {
            case ItemType.Food:
                HealthController.instance.IncreaseHealth(item.restoreHealth);
                StaminaController.instance.IncreaseStamina(item.restoreStamina);
                Debug.Log(item.restoreSanity);
                break;
            case ItemType.Question:

                break;
            default:
                break;
        }
        RemoveItem();
    }

    public void ItemDetail()
    {
        ItemDetailManager.Instance.nameitem = item.itemName;
        ItemDetailManager.Instance.description = item.description;
        ItemDetailManager.Instance.health = item.restoreHealth;
        ItemDetailManager.Instance.stamina = item.restoreStamina;
        ItemDetailManager.Instance.sanity = item.restoreSanity;
        ItemDetailManager.Instance.SetActivePanel(true);
    }
}
