using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [SerializeField] private Animator animation;
    [SerializeField] private float timeTransition;
    private static FadeController instance;

    private void Start()
    {
        instance = this;
    }

    public static FadeController GetInstance()
    {
        return instance;
    }

    private IEnumerator Fadetransition()
    {
        animation.SetTrigger("Start");
        yield return new WaitForSeconds(timeTransition);
        animation.SetTrigger("Start");
    }

    public void PlayFadetransition()
    {
        StartCoroutine(Fadetransition());
    }
}
