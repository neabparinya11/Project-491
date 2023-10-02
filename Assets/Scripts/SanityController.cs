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
    [SerializeField] GameObject sanity1, sanity2, sanity3;

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
        ShowLevelSanity();
    }

    public void DecreaseSanity(float _value)
    {
        playerSanity -= _value;
    }

    public void IncreaseSanity(float _value)
    {
        playerSanity += _value;
    }

    protected void ShowLevelSanity()
    {
        int checkLevel = (int)playerSanity / 64;
        switch (checkLevel)
        {
            case 0:
                sanity1.SetActive(false);
                sanity2.SetActive(false);
                sanity3.SetActive(false);
                break;
            case 1:
                sanity1.SetActive(true); 
                sanity2.SetActive(false);
                sanity3.SetActive(false);
                break;
            case 2:
                sanity1.SetActive(true);
                sanity2.SetActive(true);
                sanity3.SetActive(false);
                break;
            case 3:
                sanity1.SetActive(true);
                sanity2.SetActive(true);
                sanity3.SetActive(true);
                break;
        }
    }
}
