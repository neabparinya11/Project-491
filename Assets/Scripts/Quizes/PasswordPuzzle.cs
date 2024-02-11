using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PasswordPuzzle : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI uitext;
    [SerializeField] Button[] listBtn;
    [SerializeField] string passCode;
    [SerializeField] DoorAction doorAction;
    protected string answer;
    [SerializeField] string correctAnswer;
    [SerializeField] GameObject passwordPanel;

    protected UnityEvent callbackFunction;
    protected int answerIndex = 0;
    
    public void ReceiveCallbackFunction(UnityEvent _function)
    {
        callbackFunction = _function;
    }
    public void GeneratePasscode(string correctAnswer)
    {
        this.correctAnswer = correctAnswer;
        passwordPanel.SetActive(true);
    }
    public void ConcatAnswer(string _answer)
    {
        passCode += _answer;
        uitext.text = passCode;
        answerIndex++;
    }

    public void EnterPassword()
    {
        if (passCode == correctAnswer)
        {
            StartCoroutine(WhenIsPass());
        }
        else
        {
            StartCoroutine(CheckAndClear());
        }
    }

    private IEnumerator CheckAndClear()
    {
        passCode = "Failed";
        uitext.text = passCode;
        yield return new WaitForSeconds(2.0f);
        ClearPassword();
    }

    private IEnumerator WhenIsPass()
    {
        passCode = "Success";
        uitext.text = passCode;
        yield return new WaitForSeconds(2.0f);
        doorAction.SetDoorLocked(false);
        passwordPanel.SetActive(false);
        callbackFunction?.Invoke();
    }
    public void ClearPassword()
    {
        answerIndex = 0;
        answer = string.Empty;
        passCode = string.Empty;
        uitext.text = passCode;
    }

}
