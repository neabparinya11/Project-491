using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour, IDataPersistances
{
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] TextMeshProUGUI nameTag;
    [SerializeField] GameObject[] choices;
    [SerializeField] bool useInCutscene;
    [SerializeField] float speedSentence;
    [SerializeField] PlayerMovmentsScript playerMovmentsScript;
    private TextMeshProUGUI[] choicesText;
    private static DialogManager instance;
    public Story currentStory { get; private set; }
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

        if (currentStory.currentChoices.Count == 0 && Input.GetMouseButtonDown(((int)MouseButton.Left)) || Input.GetKeyDown(KeyCode.Space))
        {
            if (useInCutscene)
            {
                CutsceneController1.GetInstance().ContinueTimeLine();
            }
            ContinueStory();
        }
    }

    public void EnterDialogMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        currentStory.variablesState["playerName"] = currentName;
        playerMovmentsScript.disable = true;
        dialogIsPlaying = true;
        dialogPanel.SetActive(true);

        ContinueStory();
    }


    private IEnumerator ExitDialogMode()
    {
        CutsceneController1.GetInstance().ExitTimeLine();
        yield return new WaitForSeconds(0.2f);
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
        nameTag.text = "";
        playerMovmentsScript.disable = false;
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string[] data = currentStory.Continue().Split(":");
            dialogText.text = data[1];
            //StartCoroutine(WriteSentences(data[1]));
            nameTag.text = data[0];
            if (useInCutscene)
            {
                CutsceneController1.GetInstance().StopTimeLine();
            }
            //if (currentStory.Continue().Split(":")[0] == "ตัวเรา")
            //{
            //    nameTag.text = currentName;
            //}
            //else
            //{
            //    nameTag.text = currentStory.Continue().Split(":")[0];
            //}
            DisplayChoices();
        }
        else
        {
            //Exit dialog
            StartCoroutine(ExitDialogMode());
        }
    }

    public void SaveData(ref GameData gameData)
    {
        
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

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        if (currentStory.currentChoices.Count == 0)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
        

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int index)
    {
        currentStory.ChooseChoiceIndex(index);
        ContinueStory();
    }

    IEnumerator WriteSentences(string sentence)
    {
        dialogText.text = "";
        foreach (char charactor in sentence)
        {
            dialogText.text += charactor.ToString();
            yield return new WaitForSeconds(speedSentence);
        }
    }
}
