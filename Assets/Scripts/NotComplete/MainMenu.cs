using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Set Button")]
    [SerializeField] private Button _newGameBtn;
    [SerializeField] private Button _loadGameBtn;
    [SerializeField] private Button _quitGameBtn;
    [SerializeField] private Button _documentBtn;

    public void OnClickNewGame()
    {
        DisableAllButton();
        DataPersistances.instance.NewGame();
        //SceneManager.LoadSceneAsync("CreateNameScene");
        LoadScene.GetInstance().LoadTargetScene("CreateNameScene");
    }

    public void OnClickContinueGame()
    {
        DisableAllButton();
        DataPersistances.instance.LoadGame();
    }

    public void OnClickQuiteGame()
    {
        DisableAllButton();
        DataPersistances.instance.SaveGame();
        Application.Quit();
    }

    private void DisableAllButton()
    {
        _newGameBtn.interactable = false;
        _loadGameBtn.interactable = false;
        _quitGameBtn.interactable = false;
        _documentBtn.interactable = false;
    }

    private void Start()
    {
        if (!DataPersistances.instance.HasGameData())
        {
            _loadGameBtn.interactable = false;
        }
    }
}
