using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreateNameUser : MonoBehaviour, IDataPersistances
{
    [SerializeField] TextMeshProUGUI _inputFields;

    public void LoadData(GameData gameData)
    {
        _inputFields.text = gameData._playerName;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData._playerName = _inputFields.text;
    }


}
