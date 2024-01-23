using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundSoundMain;
    [SerializeField] private AudioSource foregroundSoundMain;

    [SerializeField] private bool useBackgroundSoundMain;
    [SerializeField] private bool useForegroundSoundMain;
    // Start is called before the first frame update
    void Start()
    {
        useBackgroundSoundMain = true;
        useForegroundSoundMain = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (useBackgroundSoundMain)
        {
            foregroundSoundMain.Pause();
            if (!backgroundSoundMain.isPlaying)
            {
                backgroundSoundMain.Play();
            }
        }

        if (useForegroundSoundMain)
        {
            backgroundSoundMain.Pause();
            if (!foregroundSoundMain.isPlaying)
            {
                foregroundSoundMain.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            useBackgroundSoundMain = false;
            useForegroundSoundMain = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            useBackgroundSoundMain = true;
            useForegroundSoundMain = false;
        }
    }
}
