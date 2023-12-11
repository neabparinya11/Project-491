using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] TextMeshProUGUI nameTag;
    private static DialogManager instance;
    private Story currentStory;
    public bool dialogIsPlaying { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
    }

    public static DialogManager GetInstance()
    {
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        if (!dialogIsPlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(((int)MouseButton.Left)) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ContinueStory();
        }
    }

    public void EnterDialogMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogIsPlaying = true;
        dialogPanel.SetActive(true);

        ContinueStory();
    }


    private void ExitDialogMode()
    {
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
        nameTag.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogText.text = currentStory.Continue().Split(":")[1];
            nameTag.text = currentStory.Continue().Split(":")[0];
        }
        else
        {
            //Exit dialog
            ExitDialogMode();
        }
    }
}
