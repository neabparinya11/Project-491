using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject timeline;
    [SerializeField] private GameObject cameraCutscene;
    [SerializeField] private GameObject teacher;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timeline.SetActive(true);
            teacher.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            cameraCutscene.SetActive(true);
            timeline.GetComponent<PlayableDirector>().Play();
        }
        
    }

    private void Update()
    {
        if (timeline.GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            cameraCutscene.SetActive(false);

        }
    }
}
