using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource audioSource;


    public static AudioManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        instance = this;
    }
    public void ChangeBackgroundMusic(AudioClip audioClip)
    {
        if (audioSource.clip.name == audioSource.name)
        {
            return;
        }
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
