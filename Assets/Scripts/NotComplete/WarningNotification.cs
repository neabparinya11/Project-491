using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WarningNotification : MonoBehaviour
{
    [SerializeField] UnityEvent OnAfterTimer;
    private GameObject window;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        window = transform.GetChild(0).gameObject;
        animator = window.GetComponent<Animator>();

        StartCoroutine(StartAnimation());
    }

    public void ShowWindow()
    {
        window.SetActive(true);
        animator.Play("Fade out Animation");
    }

    private IEnumerator StartAnimation()
    {
        ShowWindow();
        do
        {
            yield return null;
        }while (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        OnAfterTimer?.Invoke();
    }
}
