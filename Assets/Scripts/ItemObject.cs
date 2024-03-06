using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Food,
    Question
}

[Serializable]
public abstract class ItemObject : ScriptableObject
{
    public string pathSprite;
    [JsonIgnore]
    public Sprite icon;
    public ItemType type;
    public string itemName;
    [TextArea(15,20)]
    public string description;
}
