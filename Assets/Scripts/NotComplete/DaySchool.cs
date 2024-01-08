using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySchool : MonoBehaviour
{
    private static DaySchool instance;
    [SerializeField] private AudioSource backgroundSound;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        backgroundSound.loop = true;
        backgroundSound.enabled = true;
        backgroundSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public DaySchool GetInstance()
    {
        return instance;
    }
}
