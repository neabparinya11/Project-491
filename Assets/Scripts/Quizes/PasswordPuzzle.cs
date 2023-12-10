using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPuzzle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uitext;
    [SerializeField] string passCode;
    protected string answer;
    [SerializeField] string correctAnswer;
    protected int answerIndex = 0;
    
    public void ConcatAnswer(string _answer)
    {
        answerIndex++;
        passCode += _answer;
        uitext.text = passCode;
    }

    public void EnterPassword()
    {
        if (passCode == correctAnswer)
        {
            passCode = "Success";
            uitext.text = passCode;
        }
    }

    public void ClearPassword()
    {
        answerIndex = 0;
        answer = null;
        uitext.text = answer;
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (answerIndex == 4)
        {
            EnterPassword();
        }
    }
}
