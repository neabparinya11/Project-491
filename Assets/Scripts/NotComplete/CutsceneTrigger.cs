using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour, IDataPersistances
{
    [SerializeField] private string id;
    //[SerializeField] private GameObject timeline;
    //[SerializeField] private GameObject cameraCutscene;
    [SerializeField] private GameObject teacher;
    [SerializeField] private bool deleteteacher = false;
    [SerializeField] private float fadeTime;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private DialogManager dialogManager;

    private bool showTrigger = true;
    public void LoadData(GameData gameData)
    {
        gameData.dictCutscene.TryGetValue(id, out showTrigger);
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData.dictCutscene.ContainsKey(id))
        {
            gameData.dictCutscene.Remove(id);
        }
        gameData.dictCutscene.Add(id, showTrigger);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //timeline.SetActive(true);
            teacher.SetActive(true);
            showTrigger = false;
            dialogManager.EnterDialogMode(inkJson);
            this.gameObject.GetComponent<BoxCollider>().enabled = showTrigger;
            
            //cameraCutscene.SetActive(true);
            //timeline.GetComponent<PlayableDirector>().Play();
        }
        
    }
    private void Start()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = showTrigger;
    }

    private void Update()
    {
        //if (timeline.GetComponent<PlayableDirector>().state != PlayState.Playing)
        //{
        //    cameraCutscene.SetActive(false);
        //    if (deleteteacher)
        //    {
        //        teacher.SetActive(false);
        //    }

        //}
    }
}
