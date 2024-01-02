using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour, IDataPersistances
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] TextMeshProUGUI nameTag;
    [SerializeField] GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    private static DialogManager instance;
    private Story currentStory;
    private string characterName;
    private string currentName; // name of player is be created.
    public bool dialogIsPlaying { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];

        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
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

            if (currentStory.Continue().Split(":")[0] == "������")
            {
                nameTag.text = currentName;
            }
            else
            {
                nameTag.text = currentStory.Continue().Split(":")[0];
            }

        }
        else
        {
            //Exit dialog
            ExitDialogMode();
        }
    }

    public void SaveData(ref GameData gameData)
    {
        throw new System.NotImplementedException();
    }

    public void LoadData(GameData gameData)
    {
        currentName = gameData.playerName;
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("Lenght out off bounds.");
        }
    }
}
