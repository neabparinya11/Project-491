using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textInformation;
    [SerializeField] private Image _iconItem;
    private GameObject popupWindow;

    private StringBuilder popupStringBuilder;
    private Sprite popupIcon;

    private Animator popupAnimation;
    private Coroutine queueChecking;

    private void Start()
    {
        popupWindow = transform.GetChild(0).gameObject;
        popupAnimation = popupWindow.GetComponent<Animator>();
        popupWindow.SetActive(false);
        popupStringBuilder = new StringBuilder();
        
    }

    public void AddToQueue(string information, Sprite iconInformation)
    {
        popupStringBuilder.Append(information);
        popupIcon = iconInformation;
        if (queueChecking == null)
        {
            queueChecking = StartCoroutine(CheckQueue());
        }
    }

    private void ShowPopup(string infomation)
    {
        popupWindow.SetActive(true);
        _textInformation.text = infomation;
        _iconItem.sprite = popupIcon;
        popupAnimation.Play("PopupAnimation");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupStringBuilder.ToString());
            popupStringBuilder.Clear();
            yield return new WaitForSeconds(1.0f);
            do
            {
                yield return null;
            }while (!popupAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        }while (popupStringBuilder.Length > 0);
        popupWindow.SetActive(false);
        queueChecking = null;
        popupIcon = null;
    }
}
