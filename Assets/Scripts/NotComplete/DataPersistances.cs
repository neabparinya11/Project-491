using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistances : MonoBehaviour
{
    [SerializeField]
    private string fileName;
    public static DataPersistances instance { get; private set; }
    private GameData gameData;
    private List<IDataPersistances> dataPersistances;

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {

    }

    public void SaveGame()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        this.dataPersistances = FindAllDataPersistance();
    }

    private List<IDataPersistances> FindAllDataPersistance()
    {
        return new List<IDataPersistances>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
