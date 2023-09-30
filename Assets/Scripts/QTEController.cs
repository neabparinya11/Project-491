using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEController : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] KeyCode[] listKeycode;
    [SerializeField] int countListKeycode;
    [SerializeField] float timeDuration;
    [SerializeField] Image timeSlide;
    [SerializeField] CanvasGroup timeCanvas;
    [SerializeField] Sprite[] listSprite;
    [SerializeField] GameObject problem1, problem2, problem3;

    protected List<KeyCode> keycodeProblem = new List<KeyCode>();
    protected List<Sprite> imageKeyCodeProblem = new List<Sprite>();
    protected int countKeycodeCheck = 0;
    protected bool isQTEenable = false;
    protected bool isChecked = false;
    protected bool pb1 = false, pb2 = false, pb3 = false;

    // Start is called before the first frame update
    void Start()
    {
        timeCanvas.alpha = 0;
        RandomKeyCode();
        countKeycodeCheck = keycodeProblem.Count;
        isQTEenable=true;
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
        }
    }

    protected void RandomKeyCode()
    {
        for (int index = 0; index < 3; index++)
        {
            int random = UnityEngine.Random.Range(0, countListKeycode);
            keycodeProblem.Add(listKeycode[random]);
            Debug.Log(keycodeProblem[index]);
            imageKeyCodeProblem.Add(listSprite[random]);
        }
    }

    protected void ShowImageKey()
    {
        timeCanvas.alpha = 1;
        timeSlide.fillAmount += Time.deltaTime / timeDuration;
        problem1.GetComponent<Image>().sprite = imageKeyCodeProblem[0];
        problem2.GetComponent<Image>().sprite = imageKeyCodeProblem[1];
        problem3.GetComponent<Image>().sprite = imageKeyCodeProblem[2];

        if (!pb1 && !pb2 && !pb3 )
        {
            problem1.SetActive(true);
            problem2.SetActive(true);
            problem3.SetActive(true);
        }

        if (timeSlide.fillAmount == 1)
        {
            timeCanvas.alpha = 0;
            isQTEenable = false;
        }
    }

    protected bool CheckedKeyInput()
    {
        if (Input.GetKeyDown(keycodeProblem[0]))
        {
            problem1.SetActive(false);
            pb1 = true;
        }

        if (Input.GetKeyDown(keycodeProblem[1]) && pb1)
        {
            problem2.SetActive(false);
            pb2 = true;
        }

        if (Input.GetKeyDown(keycodeProblem[2]) && pb2 && pb1)
        {
            problem3.SetActive(false);
            pb3 = true;
        }

        if (pb1 && pb2 && pb3)
        {
            return true;
        }
        else
        {
            return false;
        } 
    }

    protected void Success()
    {
        isQTEenable = false;
        keycodeProblem.Clear();
        imageKeyCodeProblem.Clear();

    }
}
