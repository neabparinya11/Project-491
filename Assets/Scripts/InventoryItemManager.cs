using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                //SanityController.instance.IncreaseS(item.restoreSanity);
                SanityController.instance.IncreaseSanity(item.restoreSanity);
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
        //Clear
        ItemDetailManager.Instance.ClearDetail();
        //ItemDetailManager.Instance.useItemBtn.onClick.RemoveAllListeners();
        //ItemDetailManager.Instance.dropItemBtn.onClick.RemoveAllListeners();

        //Set
        ItemDetailManager.Instance.nameitem = item.itemName;
        ItemDetailManager.Instance.description = item.description;
        ItemDetailManager.Instance.health = item.restoreHealth;
        ItemDetailManager.Instance.stamina = item.restoreStamina;
        ItemDetailManager.Instance.sanity = item.restoreSanity;
        ItemDetailManager.Instance.SetActivePanel(true);
        ItemDetailManager.Instance.useItemBtn.onClick.AddListener(() =>
        {
            UseItem();
            ItemDetailManager.Instance.detailPanel.SetActive(false);
        });
        ItemDetailManager.Instance.dropItemBtn.onClick.AddListener(() =>
        {
            RemoveItem();
            ItemDetailManager.Instance.detailPanel.SetActive(false);
        });
    }
}
