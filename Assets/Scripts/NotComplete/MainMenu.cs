using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void OnClickNewGame()
    {
        DataPersistances.instance.NewGame();
    }

    public void OnClickContinueGame()
    {
        DataPersistances.instance.LoadGame();
    }

}
