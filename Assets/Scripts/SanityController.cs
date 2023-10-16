using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{

    public static SanityController instance;
    [SerializeField] protected float maxSanity; // 255 is max 
    [SerializeField] protected float minSanity; // 0 is min
    [SerializeField] protected float playerSanity; // 0 - 255 is range of player sanity
    [SerializeField] protected RawImage fieldView;

    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        Color newColor = fieldView.color;
        newColor.a = 1 - playerSanity/maxSanity;
        fieldView.color = newColor;
    }

    public void DecreaseSanity(float _value)
    {
        playerSanity -= _value;
    }

    public void IncreaseSanity(float _value)
    {
        playerSanity += _value;
    }
}
