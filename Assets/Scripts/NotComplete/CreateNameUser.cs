using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateNameUser : MonoBehaviour, IDataPersistances
{
    [SerializeField] TextMeshProUGUI _informationField;
    [SerializeField] GameObject _objConfirmGroup;
    [SerializeField] GameObject _objCreateGroup;
    [SerializeField] TMP_InputField _inputNameField;
    [SerializeField] Button _yesBtn;
    [SerializeField] Button _noBtn;
    [SerializeField] Button _confirmBtn;
    [SerializeField] Button _cancelBtn;

    public string _playerName { get; private set; }
    public void LoadData(GameData gameData)
    {
        _playerName = gameData.playerName;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.playerName = _playerName;
    }

    public void OnConfirmClick()
    {
        _objCreateGroup.SetActive(false);
        _objConfirmGroup.SetActive(true);
        if (_playerName != "")
        {
            _informationField.text = "คุณต้องการใช้ชื่อ " + _playerName + " ใช่หรือไม่";
        }      
    }

    public void OnCancelClick()
    {
        DisableConfirmCancelButton();
        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void OnYesClick()
    {
        DisableYesNoButton();
        DataPersistances.instance.SaveGame();
        SceneManager.LoadSceneAsync("DialogPlayScene");
    }

    public void OnNoClick()
    {
        _objConfirmGroup.SetActive(false);

        _objCreateGroup.SetActive(true);


    }

    private void Update()
    {
        _playerName = _inputNameField.text;
    }

    private void DisableYesNoButton()
    {
        _yesBtn.interactable = false;
        _noBtn.interactable = false;
    }

    private void DisableConfirmCancelButton()
    {
        _confirmBtn.interactable = false;
        _cancelBtn.interactable = false;
    }
}
