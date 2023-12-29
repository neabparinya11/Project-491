using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateNameUser : MonoBehaviour, IDataPersistances
{
    [SerializeField] TextMeshProUGUI _informationField;
    [SerializeField] GameObject _objConfirmGroup;
    [SerializeField] GameObject _objCreateGroup;
    [SerializeField] TMP_InputField _inputNameField;

    public string _name { get; private set; }
    public void LoadData(GameData gameData)
    {
        _name = gameData._playerName;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData._playerName = _name;
    }

    public void OnConfirmClick()
    {
        _objCreateGroup.SetActive(false);
        _objConfirmGroup.SetActive(true);
        if (_name != "")
        {
            _informationField.text = "คุณต้องการใช้ชื่อ " + _name + " ใช่หรือไม่";
        }
        else
        {

        }
        
    }

    public void OnCancelClick()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void OnYesClick()
    {
        SceneManager.LoadScene("next");
    }

    public void OnNoClick()
    {
        _objConfirmGroup.SetActive(false);

        _objCreateGroup.SetActive(true);


    }

    private void Update()
    {
        _name = _inputNameField.text;
    }

}
