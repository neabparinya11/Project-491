using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistances : MonoBehaviour
{
    [SerializeField] private string fileName;
    public static DataPersistances instance { get; private set; }
    private GameData gameData;
    private List<IDataPersistances> dataPersistances;
    private FileDataHandle fileDataHandle;

    public void NewGame()
    {
        this.fileDataHandle = new FileDataHandle(Application.persistentDataPath, fileName);
        this.gameData = new GameData();
        LoadGame();
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandle.Load();
        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistances dataPersistanceObj in dataPersistances)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistances dataPersistanceObj in dataPersistances)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        fileDataHandle.Save(gameData);
    }
    // Start is called before the first frame update
    void Start()
    {
        this.dataPersistances = FindAllDataPersistance();
    }

    private List<IDataPersistances> FindAllDataPersistance()
    {
        IEnumerable<IDataPersistances> dataObjects = FindObjectOfType<MonoBehaviour>().GetComponents<IDataPersistances>();
        return new List<IDataPersistances>(dataObjects);
    }

}
