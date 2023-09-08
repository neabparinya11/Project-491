using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food Item", menuName = "item/Food item")]
public class FoodItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Food;
    }


}
