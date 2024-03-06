using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItemDetail : MonoBehaviour
{
    public static QuestionItemDetail instance;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI questionItemName;
    [SerializeField] TextMeshProUGUI questionItemDetail;
    // Start is called before the first frame update

    public string questItemName, questItemDetail;
    void Start()
    {
        instance = this;
        questionItemDetail.text = "";
        questionItemName.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        questionItemName.text = questItemName;
        questionItemName.color = Color.white;
        questionItemDetail.text = questItemDetail;
        questionItemDetail.color = Color.white;
    }

    public void ClearAllDetail()
    {
        questItemName = "";
        questItemDetail = "";
    }

    public void SetActivate(bool _value)
    {
        panel.SetActive(_value);
    }
}
