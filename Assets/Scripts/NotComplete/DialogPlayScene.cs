using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogPlayScene : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] DialogManager manager;
    [SerializeField] AudioClip[] listAudio;
    [SerializeField] AudioSource soundSource;
    private bool theFirst = true;

    private void Start()
    {
        StartCoroutine(StartDialog());
        if(soundSource != null)
        {
            StartCoroutine(StartSounds());
        }
    }

    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(0.1f);
        DialogManager.GetInstance().EnterDialogMode(inkJson);

    }

    IEnumerator StartSounds()
    {
        foreach (AudioClip sound in listAudio)
        {
            soundSource.clip = sound;
            soundSource.Play();
            yield return new WaitForSeconds(sound.length);
        }
    }
    private void Update()
    {
        if (DialogManager.GetInstance().currentStory == null)
        {
            return;
        }
    }
}
