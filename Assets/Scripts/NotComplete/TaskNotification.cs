using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TaskNotification : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI taskStatus;
    [SerializeField] private TextMeshProUGUI taskHeader;

    private GameObject popupWindow;
    private StringBuilder popupStatusStringBuilder;
    private StringBuilder popupHeaderStringBuilder;
    private Animator popupAnimator;
    private Coroutine popupCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        popupWindow = transform.GetChild(0).gameObject;
        popupAnimator = popupWindow.GetComponent<Animator>();
        popupWindow.SetActive(false);
        popupStatusStringBuilder = new StringBuilder();
        popupHeaderStringBuilder = new StringBuilder();
    }

    public void AddTaskToQueue(TaskComponent task)
    {
        popupHeaderStringBuilder.Append(task.headTask);
        popupStatusStringBuilder.Append(task.isComplete?"สำเร็จ":"ภารกิจใหม่");
        if (popupCoroutine == null)
        {
            popupCoroutine = StartCoroutine(QueueChecking());
        }
    }

    private void ShowPopup(string _taskHeader, string _taskStatus)
    {
        popupWindow.SetActive(true);
        taskStatus.text = _taskStatus;
        taskHeader.text = _taskHeader;
        popupAnimator.Play("Task Notification Animation");
    }
    private IEnumerator QueueChecking()
    {
        do
        {
            ShowPopup(popupHeaderStringBuilder.ToString(), popupStatusStringBuilder.ToString());
            popupHeaderStringBuilder.Clear();
            popupStatusStringBuilder.Clear();
            yield return new WaitForSeconds(1.0f);
            do
            {
                yield return null;
            }while (!popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        } while (popupHeaderStringBuilder.Length > 0);
        popupWindow.SetActive(false);
        popupCoroutine = null;
    }
}
