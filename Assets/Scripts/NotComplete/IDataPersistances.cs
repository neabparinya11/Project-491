using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistances
{
    public void SaveDta(ref GameData gameData);

    public void LoadDta(GameData gameData);
}
