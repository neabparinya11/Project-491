using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{

    protected static SanityController instance;
    [SerializeField] protected float maxSanity; // 255 is max 
    [SerializeField] protected float minSanity; // 0 is min
    [SerializeField] protected float playerSanity; // 0 - 255 is range of player sanity
    [SerializeField] protected RawImage fieldView;
    [SerializeField] GameObject sanity1, sanity2, sanity3;

    // Update is called once per frame
    void Update()
    {
        Color newColor = fieldView.color;
        newColor.a = playerSanity/maxSanity;
        fieldView.color = newColor;
    }

    protected void DecreaseSanity(float _value)
    {
        playerSanity -= _value;
    }

    protected void IncreaseSanity(float _value)
    {
        playerSanity += _value;
    }

    protected void ShowLevelSanity()
    {
        int checkLevel = (int)playerSanity / 64;
        
    }
}
