using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskDetailManager : MonoBehaviour
{
    private static TaskDetailManager instance;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI contentText;

    public string taskHeader, taskDetail;
    public static TaskDetailManager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        headerText.text = string.Empty;
        contentText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        headerText.text = taskHeader;
        contentText.text = taskDetail;
    }

    public void ClearAllDetail()
    {
        headerText.text = string.Empty;
        contentText.text = string.Empty;
    }

    public void SetctivtePanel(bool _value)
    {
        panel.SetActive(_value);
    }
}
