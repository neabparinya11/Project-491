using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private GameObject cameraCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            cameraCutscene.SetActive(true);
            timeline.Play();
        }
        
    }

    private void Update()
    {
        if (timeline.state != PlayState.Playing)
        {
            cameraCutscene.SetActive(false);
        }
    }
}
