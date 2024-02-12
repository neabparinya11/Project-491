using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Food Item", menuName = "Item/Food item")]
public class FoodItem : ItemObject
{
    public float restoreHealth;
    public float restoreStamina;
    public float restoreSanity;
    private void Awake()
    {
        type = ItemType.Food;
    }


}
