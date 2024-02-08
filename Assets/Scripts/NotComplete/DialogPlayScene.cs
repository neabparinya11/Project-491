using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogPlayScene : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] DialogManager manager;
    private bool theFirst = true;

    private void Start()
    {
        StartCoroutine(StartDialog());
    }

    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(0.1f);
        DialogManager.GetInstance().EnterDialogMode(inkJson);
    }

    private void Update()
    {
        if (DialogManager.GetInstance().currentStory == null)
        {
            return;
        }
    }
}
