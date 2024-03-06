using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataHandle
{
    private string dataDirPath = "";
    private string dataFileName = "";

    /// <summary>
    /// Constructor of class, it's keep data direcction.
    /// </summary>
    /// <param name="_path"> String: this is path direction to save data.</param>
    /// <param name="_fileName">String: this is file name to save data.</param>
    public FileDataHandle(string _path, string _fileName)
    {
        this.dataDirPath = _path;
        this.dataFileName = _fileName;
    }

    /// <summary>
    /// Load data from json file and convert to file type GameData.
    /// </summary>
    /// <returns></returns>
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader read = new StreamReader(stream))
                    {
                        dataToLoad = read.ReadToEnd();
                    }
                }

                //loadData = JsonUtility.FromJson<GameData>(dataToLoad);
                loadData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
            }catch (Exception e)
            {
                Debug.LogError("Error: " + e.Message);
            }
        }
        return loadData;
    }

    /// <summary>
    /// Save GameData to local storage, by convert to json file.
    /// </summary>
    /// <param name="gameData"></param>
    public void Save(GameData gameData)
    {
        //string fullpath
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            //string dataToStore = JsonUtility.ToJson(gameData, true);
            string dataToStore2 = JsonConvert.SerializeObject(gameData, Formatting.Indented);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(dataToStore2);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
        }
    }
}
