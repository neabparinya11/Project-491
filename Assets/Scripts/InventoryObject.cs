using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    public int lenghtContainer = 0;

    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
    }
}

[SerializeField]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
} 
