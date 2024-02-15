using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Ink.UnityIntegration;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour, IDataPersistances
{
    [Header("Global Ink File")]
    [SerializeField] private InkFile globalInkFile;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] TextMeshProUGUI dialogText;     
    [SerializeField] TextMeshProUGUI nameTag;
    [SerializeField] GameObject[] choices;
    [SerializeField] bool useInCutscene;
    [SerializeField] float speedSentence;
    [SerializeField] PlayerMovmentsScript playerMovmentsScript;
    [SerializeField] string nextScene;
    [SerializeField] bool useNextScene;
    private TextMeshProUGUI[] choicesText;
    private static DialogManager instance;
    private Sprite imagePanel;
    private bool setImage = false; 
    public Story currentStory { get; private set; }
    private string currentName; // name of player is be created.
    public bool dialogIsPlaying { get; private set; }
    private DialogueVariable dialogueVariable;
    private UnityEvent callbackExitDialogue;
    private UnityEvent callbackEnterDialogue;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        dialogueVariable = new DialogueVariable(globalInkFile.filePath);
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

        if (setImage)
        {
            dialogPanel.GetComponent<Image>().sprite = imagePanel;
        }
    }

    public void EnterDialogMode(TextAsset inkJson)
    {
        callbackEnterDialogue?.Invoke();
        currentStory = new Story(inkJson.text);
        dialogueVariable.StartListening(currentStory);
        currentStory.variablesState["playerName"] = currentName;
        if (playerMovmentsScript != null)
        {
            playerMovmentsScript.disable = true;
        }
        dialogIsPlaying = true;
        dialogPanel.SetActive(true);

        ContinueStory();
    }


    private IEnumerator ExitDialogMode()
    {
        if (useInCutscene)
        {
            CutsceneController1.GetInstance().ExitTimeLine();
        }
        yield return new WaitForSeconds(0.2f);
        dialogueVariable.StopListening(currentStory);
        dialogIsPlaying = false;
        dialogPanel.SetActive(false);
        dialogText.text = "";
        nameTag.text = "";
        if (playerMovmentsScript != null)
        {
            playerMovmentsScript.disable = false;
        }

        if (useNextScene)
        {
            LoadScene.GetInstance().LoadTargetScene(nextScene);
        }
        callbackExitDialogue?.Invoke();
    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            string[] data = currentStory.Continue().Split(":");
            dialogText.text = data[1];
            nameTag.text = data[0];
            if (useInCutscene)
            {
                CutsceneController1.GetInstance().StopTimeLine();
            }
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

        if (choices.Length != 0)
        {
            StartCoroutine(SelectFirstChoice());
        }
        
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

    public void SetBackgroundPanel(Sprite bgImage, bool setImage)
    {
        this.imagePanel = bgImage;
        this.setImage = setImage;
    }

    public void EnterDialogueWithTime(float timer, TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        currentStory.variablesState["playerName"] = currentName;
        if (playerMovmentsScript != null)
        {
            playerMovmentsScript.disable = true;
        }
        dialogIsPlaying = true;
        dialogPanel.SetActive(true);
        StartCoroutine(PlayDialogueWithTime(timer));
    }

    IEnumerator PlayDialogueWithTime(float timer)
    {
        ContinueStory();
        yield return new WaitForSeconds(timer);
        StartCoroutine(ExitDialogMode());
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariable.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("");
        }
        return variableValue;
    }

    public void RecieveCallbackOnExitDialogue(UnityEvent function)
    {
        this.callbackExitDialogue = function;
    }

    public void RecieveCallbackOnEnterDialogue(UnityEvent function)
    {
        this.callbackEnterDialogue = function;
    }
}
