using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "Item/Food item")]
public class FoodItem : ItemObject
{
    [SerializeField] int restoreHealth;
    [SerializeField] int restoreStamina;
    [SerializeField] int restoreSanity;
    private void Awake()
    {
        type = ItemType.Food;
    }


}
