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
    //[SerializeField] GameObject problem1, problem2, problem3;
    [SerializeField] GameObject problem1;

    protected List<KeyCode> keycodeProblem = new List<KeyCode>();
    protected List<Sprite> imageKeyCodeProblem = new List<Sprite>();
    protected int countKeycodeCheck = 0;
    public bool isQTEenable;
    protected bool isChecked = false, onClick = false, start;
    //protected bool pb1 = false, pb2 = false, pb3 = false;
    protected bool pb1 = false;
    protected float countTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timeCanvas.alpha = 0;
        RandomKeyCode();
        countKeycodeCheck = keycodeProblem.Count;
        isQTEenable = false;
        start = true;
        UpdateTimeSlide();
        problem1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isQTEenable)
        {
            ShowImageKey();
            isChecked = CheckedKeyInput();
            if (isChecked)
            {
                Success();
            }
            else
            {
                if (!start)
                {
                    timeCanvas.alpha = 0;
                }
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
        UpdateTimeSlide();
        if (countTime <= timeDuration - 0.01f)
        {
            if (start)
            {
            countTime += regenTime * Time.deltaTime;
            UpdateTimeSlide();
            }
            
            if (countTime >= timeDuration)
            {
                timeCanvas.alpha = 0;
                start = false;
                isQTEenable = false;
            }
        }
        //problem2.GetComponent<Image>().sprite = imageKeyCodeProblem[1];
        //problem3.GetComponent<Image>().sprite = imageKeyCodeProblem[2];

        //if (!pb1 && !pb2 && !pb3 )
        //{
        //    problem1.SetActive(true);
        //    problem2.SetActive(true);
        //    problem3.SetActive(true);
        //}
    }

    protected void UpdateTimeSlide()
    {
        timeSlide.fillAmount = countTime / timeDuration;
    }

    protected bool CheckedKeyInput()
    {

        if (Input.GetKeyDown(keycodeProblem[0]))
        {
            onClick = true;
            problem1.SetActive(false);
            pb1 = true;
            start = false;
        }

        //if (!Input.GetKeyDown(keycodeProblem[0]))
        //{
        //    onClick = true;
        //    start = false;
        //    pb1 = false;
        //}

        //if (Input.GetKeyDown(keycodeProblem[1]) && pb1 )
        //{
        //    problem2.SetActive(false);
        //    if (pb2 && Time.time - lastedBetweenPress <= 0.8f)
        //    {

        //    }
        //    pb2 = true;
        //    lastedBetweenPress = Time.time;
        //}

        //if (Input.GetKeyDown(keycodeProblem[2]) && pb2 && pb1)
        //{
        //    problem3.SetActive(false);
        //    if (pb2 && Time.time - lastedBetweenPress <= 0.8f)
        //    {

        //    }
        //    pb3 = true;
        //    lastedBetweenPress = Time.time;
        //}

        //if (pb1 && pb2 && pb3)
        //{
        //    return true;
        //}
        return pb1;
    }

    protected void Success()
    {
        isQTEenable = false;
        timeCanvas.alpha = 0;
        //keycodeProblem.Clear();
        //imageKeyCodeProblem.Clear();
    }
}
