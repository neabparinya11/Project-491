using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        _informationField.text = "คุณต้องการใช้ชื่อ " + _name + " ใช่หรือไม่";
    }

    public void OnCancelClick()
    {
        Debug.Log("Cac=ncel click");
    }

    public void OnYesClick()
    {

    }

    public void OnNoClick()
    {

    }

    private void Update()
    {
        _name = _inputNameField.text;
    }

}
