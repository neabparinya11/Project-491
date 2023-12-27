using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void OnClickNewGame()
    {
        DataPersistances.instance.NewGame();
        SceneManager.LoadScene("");
        
    }

    public void OnClickContinueGame()
    {
        DataPersistances.instance.LoadGame();
    }

    public void OnClickQuiteGame()
    {
        DataPersistances.instance.SaveGame();
        Application.Quit();
    }

}
