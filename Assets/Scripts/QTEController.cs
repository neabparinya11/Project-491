using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    public static QTEController instance;
    [Header("Configuration")]
    [SerializeField] KeyCode[] listKeycode;
    [SerializeField] int countListKeycode;
    [SerializeField] float timeDuration;
    [SerializeField] Image timeSlide;
    [SerializeField] CanvasGroup timeCanvas;
    [SerializeField] Sprite[] listSprite;
    [SerializeField] float regenTime;
    [SerializeField] GameObject problem1, problem2, problem3;
    [SerializeField] DialogManager cutsceneController;
    [SerializeField] TextAsset inkJson;
    [SerializeField] GameObject characterObject;
    [SerializeField] GameObject qteTriggger;
    //[SerializeField] GameObject problem1;

    protected List<KeyCode> keycodeProblem = new List<KeyCode>();
    protected List<Sprite> imageKeyCodeProblem = new List<Sprite>();
    protected int countKeycodeCheck = 0;
    public bool isQTEenable, start;
    protected bool isChecked = false;
    protected bool pb1 = false, pb2 = false, pb3 = false;
    //protected bool pb1 = false, onClick = false;
    protected float countTime = 0;
    protected int countKeyDown = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //RandomKeyCode();
        countKeycodeCheck = keycodeProblem.Count;
        //GeneratePattern();
    }

    // Update is called once per frame
    void Update()
    {
        if (isQTEenable)
        {
            ShowImageKey();
            isChecked = CheckedKeyInput();
            if (isChecked && countKeyDown == 3)
            {
                Success();
                cutsceneController.EnterDialogueWithTime(1.5f, inkJson);
                characterObject.SetActive(true);
                qteTriggger.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                FailedPuzzle();
            }
        }
    }

    protected void RandomKeyCode()
    {
        for (int index = 0; index < 3; index++)
        {
            int random = UnityEngine.Random.Range(0, countListKeycode);
            keycodeProblem.Add(listKeycode[random]);
            imageKeyCodeProblem.Add(listSprite[random]);
        }
    }

    protected void ShowImageKey()
    {
        timeCanvas.alpha = 1;
        problem1.GetComponent<Image>().sprite = imageKeyCodeProblem[0];
        problem2.GetComponent<Image>().sprite = imageKeyCodeProblem[1];
        problem3.GetComponent<Image>().sprite = imageKeyCodeProblem[2];
        UpdateTimeSlide();
        if (countTime <= timeDuration - 0.01f)
        {
            if (start)
            {
                countTime += regenTime * Time.deltaTime;
                UpdateTimeSlide();
            }

            if (countTime >= timeDuration - 0.01f)
            {
                timeCanvas.alpha = 0;
                start = false;
                isQTEenable = false;
            }
        }
    }

    protected void UpdateTimeSlide()
    {
        timeSlide.fillAmount = countTime / timeDuration;
    }

    protected bool CheckedKeyInput()
    {
        switch (countKeyDown)
        {
            case 0:
                if (Input.GetKeyDown(keycodeProblem[countKeyDown]))
                {
                    problem1.SetActive(false);
                    pb1 = true;
                    countKeyDown++;
                } else if (CheckedArrowKeyInput())
                {
                    countKeyDown++;
                }
                break;
            case 1:
                if (Input.GetKeyDown(keycodeProblem[countKeyDown]))
                {
                    problem2.SetActive(false);
                    pb2 = true;
                    countKeyDown++;
                }
                else if (CheckedArrowKeyInput())
                {
                    countKeyDown++;
                }
                break;
            case 2:
                if (Input.GetKeyDown(keycodeProblem[countKeyDown]))
                {
                    problem3.SetActive(false);
                    pb3 = true;
                    countKeyDown++;
                }
                else if (CheckedArrowKeyInput())
                {
                    countKeyDown++;
                }
                break;
            default:
                start = false;
                break;
        }
        return pb1 && pb2 && pb3;
    }

    protected void Success()
    {
        start = false;
        isQTEenable = false;
        timeCanvas.alpha = 0;
        countKeyDown = 0;
        keycodeProblem.Clear();
        imageKeyCodeProblem.Clear();
        problem1.SetActive(true);
        problem2.SetActive(true);
        problem3.SetActive(true);
    }

    protected void FailedPuzzle()
    {
        if (!start)
        {
            start = false;
            isQTEenable = false;
            timeCanvas.alpha = 0;
            countKeyDown = 0;
            keycodeProblem.Clear();
            imageKeyCodeProblem.Clear();
            problem1.SetActive(true);
            problem2.SetActive(true);
            problem3.SetActive(true);
        }
    }

    protected bool CheckedArrowKeyInput()
    {
        return Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow);
    }

    public void GeneratePattern()
    {
        RandomKeyCode();
        isQTEenable = true;
        start = true;
    }
}
