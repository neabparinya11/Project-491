using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private string id;
    //[SerializeField] private GameObject timeline;
    //[SerializeField] private GameObject cameraCutscene;
    [SerializeField] private GameObject teacher;
    [SerializeField] private float fadeTime;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private Sprite dialogueBackground;
    [SerializeField] private bool setBackgroundImage;
    [SerializeField] private bool setDisableTeacher;
    [SerializeField] private bool useCutscene;
    [SerializeField] private AudioSource[] listSoundsOnTrigger;
    [SerializeField] private bool playBeforeCutscene;
    private bool isFirst = true;
    private bool showTrigger = true;

    //public void LoadData(GameData gameData)
    //{
    //    gameData.dictCutscene.TryGetValue(id, out showTrigger);
    //}

    //public void SaveData(ref GameData gameData)
    //{
    //    if (gameData.dictCutscene.ContainsKey(id))
    //    {
    //        gameData.dictCutscene.Remove(id);
    //    }
    //    gameData.dictCutscene.Add(id, showTrigger);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //timeline.SetActive(true);
            if (teacher != null)
            {
                teacher.SetActive(true);
            }
            showTrigger = false;
            dialogManager.EnterDialogMode(inkJson);
            this.gameObject.GetComponent<BoxCollider>().enabled = showTrigger;
            if (teacher != null && setDisableTeacher)
            {
                teacher.SetActive(false);
            }

            dialogManager.SetBackgroundPanel(dialogueBackground, setBackgroundImage);
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
        if (playBeforeCutscene)
        {
            
        }
    }

    private void PlayListSound()
    {
        for (int i = 0; i< listSoundsOnTrigger.Length - 1; i++)
        {
            listSoundsOnTrigger[i].Play();
            if (!listSoundsOnTrigger[i].isPlaying)
            {
                listSoundsOnTrigger[i+1].Play();
            }
        }

    }
}
