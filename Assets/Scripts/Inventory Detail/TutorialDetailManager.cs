using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDetailManager : MonoBehaviour
{
    private static TutorialDetailManager instance;
    [SerializeField] private GameObject detailPanel;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI bodyTextForImage;
    [SerializeField] private TextMeshProUGUI bodyTextForNonImage;
    [SerializeField] private Image imageFeild;

    public string headerTutorial, bodyTutorial;
    public Sprite imageTutorial;
    public static TutorialDetailManager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        headerText.text = string.Empty;
        bodyTextForImage.text = string.Empty;
        bodyTextForNonImage.text = string.Empty;
        imageFeild.sprite = null;
    }

    // Update is called once per frame
    void Update()
    {
        headerText.text = headerTutorial;
        if (imageTutorial != null)
        {
            bodyTextForImage.text = bodyTutorial;
            imageFeild.sprite = imageTutorial;
        }
        else
        {
            bodyTextForNonImage.text = bodyTutorial;
        }
    }

    public void ClearAllData()
    {
        headerText.text = string.Empty;
        bodyTextForImage.text = string.Empty;
        bodyTextForNonImage.text = string.Empty;
        imageFeild.sprite = null;
    }

    public void SetActivate(bool _value)
    {
        detailPanel.SetActive(_value);
    }
}
