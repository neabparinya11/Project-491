using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolDay : MonoBehaviour
{
    private bool isPlayTeacher = false;
    private bool dialogIsComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayTeacher && dialogIsComplete)
        {
            StartCoroutine(PlayDialogScene());
        } 
    }

    IEnumerator PlayDialogScene()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
