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
    [SerializeField] private AudioSource SoundsOnTrigger;
    [SerializeField] private AudioClip[] listSoundsClip; 
    [SerializeField] private bool playBeforeCutscene = false;
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
            teacher?.SetActive(true);
            showTrigger = false;
            if (SoundsOnTrigger == null)
            {
                dialogManager.EnterDialogMode(inkJson);
            }
            playBeforeCutscene = true;
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
        if (playBeforeCutscene && isFirst)
        {
            StartCoroutine(PlayListSound());
            isFirst = false;
        }
    }

    private IEnumerator PlayListSound()
    {
        foreach (AudioClip clip in listSoundsClip)
        {
            SoundsOnTrigger.clip = clip;
            SoundsOnTrigger.Play();
            yield return new WaitForSeconds(clip.length);
        }
        dialogManager.EnterDialogMode(inkJson);
    }
}
