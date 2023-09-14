using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IventoryManagementController : MonoBehaviour
{
    ItemObject item;

    public void RemoveItem()
    {
        InventoryManager.Instance.RemoveItem(item);
    }
}
