using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    [Header("Configuration")]
    //[SerializeField] Text promp;
    [SerializeField] KeyCode[] listKeycode;
    [SerializeField] int countListKeycode;
    //[SerializeField] GameObject content;
    [SerializeField] float timeDuration;
    [SerializeField] Image timeSlide;
    [SerializeField] CanvasGroup timeCanvas;
    [SerializeField] Sprite[] listSprite;
    [SerializeField] Image problem1, problem2, problem3;

    protected List<KeyCode> keycodeProblem = new List<KeyCode>();
    protected int countKeycodeCheck;
    protected bool isQTEenable = false;

    // Start is called before the first frame update
    void Start()
    {
        timeCanvas.alpha = 0;
        RandomKeyCode();
        countKeycodeCheck = keycodeProblem.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (isQTEenable && CheckedKeyInput())
        {
            Success();
        }
    }

    protected void RandomKeyCode()
    {
        for (int index = 0; index < 3; index++)
        {
            int random = UnityEngine.Random.Range(0, countListKeycode);
            keycodeProblem.Add(listKeycode[random]);
        }
    }

    protected void ShowImageKey()
    {
        problem1.sprite = listSprite[0];
    }

    protected bool CheckedKeyInput()
    {
        if (Input.GetKeyDown(keycodeProblem[0]))
        {
            if (Input.GetKeyDown(keycodeProblem[1]))
            {
                if (Input.GetKeyDown(keycodeProblem[2]))
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected void Success()
    {
        isQTEenable = false;
    }
}
