using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogPlayScene : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] DialogManager manager;

    private void Start()
    {
        StartCoroutine(StartDialog());
    }

    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(0.1f);
        manager.EnterDialogMode(inkJson);
    }

    private void Update()
    {
        if (!manager.currentStory.canContinue && manager != null)
        {
            SceneManager.LoadSceneAsync("Day_SchoolScene");
        }
    }
}
