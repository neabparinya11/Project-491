using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayCutscenePolice : MonoBehaviour
{
    [SerializeField] private GameObject policeObject;
    [SerializeField] private GameObject keypassObject;
    [SerializeField] private GameObject timeline;
    [SerializeField] private GameObject cutsceneCamera;

    private static PlayCutscenePolice instance;
    public bool isEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        policeObject.SetActive(true);
        keypassObject.SetActive(false);
        timeline.SetActive(false);
        cutsceneCamera.SetActive(false);
    }

    public static PlayCutscenePolice GetInstacne()
    {
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeline.GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            timeline.SetActive(false);
            cutsceneCamera.SetActive(false);
            keypassObject?.SetActive(true);
        }
    }

    public void PlayPoliceCutscene()
    {
        timeline.SetActive(true); 
        cutsceneCamera.SetActive(true);
        timeline.GetComponent<PlayableDirector>().Play();
    }
}
