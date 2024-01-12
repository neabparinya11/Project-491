using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolDay : MonoBehaviour
{
    private bool isPlayTeacher = false;
    private bool dialogIsComplete = false;
    [SerializeField] private GameObject cutsceneTimeline1;
    [SerializeField] private GameObject cutsceneCamera1;
    [SerializeField] private GameObject cutsceneTimeline2;
    [SerializeField] private GameObject cutsceneCamera2;
    [SerializeField] private GameObject police;
    [SerializeField] private GameObject keyItem;

    private bool classroomDialogIsComp;
    private bool policeDialogIsComp;

    // Start is called before the first frame update
    void Start()
    {
        classroomDialogIsComp = false;
        policeDialogIsComp = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isPlayTeacher && dialogIsComplete)
        //{
        //    StartCoroutine(PlayDialogScene());
        //} 

    }

    IEnumerator PlayDialogScene()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
