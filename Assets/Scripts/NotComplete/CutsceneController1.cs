using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneController1 : MonoBehaviour
{
    private static CutsceneController1 instance;
    [SerializeField] private PlayableDirector timeline;
    public static CutsceneController1 GetInstance()
    {
        if(instance != null)
        {
            return instance;
        }
        return instance = new CutsceneController1();
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void StopTimeLine()
    {
        timeline.Pause();
    }

    public void ContinueTimeLine()
    {
        timeline.Resume();
    }

    public void ExitTimeLine()
    {
        timeline.time = timeline.duration;
    }
}
