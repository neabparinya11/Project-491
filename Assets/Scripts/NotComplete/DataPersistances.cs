using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistances : MonoBehaviour
{
    [SerializeField] private string fileName;
    public static DataPersistances instance { get; private set; }
    private GameData gameData;
    private List<IDataPersistances> dataPersistances;
    private FileDataHandle fileDataHandle;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than data.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        this.fileDataHandle = new FileDataHandle(Application.persistentDataPath, fileName);
    }
    public void NewGame()
    {
        //this.fileDataHandle = new FileDataHandle(Application.persistentDataPath, fileName);
        this.gameData = new GameData();
        //LoadGame();
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandle.Load();
        if (this.gameData == null)
        {
            Debug.Log("GameData is null");
            return;
        }

        foreach (IDataPersistances dataPersistanceObj in dataPersistances)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("Game data is null");
            return;
        }
        foreach (IDataPersistances dataPersistanceObj in dataPersistances)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        fileDataHandle.Save(gameData);
    }

    private List<IDataPersistances> FindAllDataPersistance()
    {
        IEnumerable<IDataPersistances> dataObjects = FindObjectOfType<MonoBehaviour>().GetComponents<IDataPersistances>();
        return new List<IDataPersistances>(dataObjects);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("On Scene Loaded");
        this.dataPersistances = FindAllDataPersistance();
        LoadGame();
    }

    public void OnSceneUnloaded(Scene scene)
    {
        Debug.Log("On Scene Unloaded");
        SaveGame();
        
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
