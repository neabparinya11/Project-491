using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogPlayScene : MonoBehaviour
{
    [SerializeField] TextAsset inkJson;
    [SerializeField] DialogManager manager;
    [SerializeField] AudioClip[] listAudioBeforeDialoge;
    [SerializeField] AudioClip[] listAudioBetweenDialogue;
    [SerializeField] AudioSource soundSource;
    [SerializeField] bool playWithSound = true;

    private void Start()
    {
        if (playWithSound && soundSource != null)
        {
            StartCoroutine(StartSounds());
        }
        else
        {
            StartCoroutine(StartDialog());
        }
    }

    IEnumerator StartDialog()
    {
        yield return new WaitForSeconds(0.1f);
        DialogManager.GetInstance().EnterDialogMode(inkJson);
    }

    IEnumerator StartSounds()
    {
        foreach (AudioClip sound in listAudioBeforeDialoge)
        {
            soundSource.clip = sound;
            soundSource.Play();
            yield return new WaitForSeconds(sound.length);
        }
        manager.EnterDialogMode(inkJson);
        foreach (AudioClip sound in listAudioBetweenDialogue)
        {
            soundSource.clip = sound;
            soundSource.Play();
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
