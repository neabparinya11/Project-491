using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    [SerializeField] GameObject imageTutorial;
    [SerializeField] Image[] listTutorial;
    [SerializeField] Button leftBtn;
    [SerializeField] Button rightBtn;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(0.9f);
        EnterTutorialMode();
    }

    public void EnterTutorialMode()
    {
        imageTutorial.SetActive(true);
        PauseSystem.instance.PauseGame();
    }

    public void ExitTutorialMode()
    {
        imageTutorial.SetActive(false);
        PauseSystem.instance.ContinueGame();
    }
}
