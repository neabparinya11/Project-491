using System.Collections;
using System.Collections.Generic;
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
    FileDataHandle(string _path, string _fileName)
    {
        this.dataDirPath = _path;
        this.dataFileName = _fileName;
    }

    public GameData Load()
    {
        return new GameData();
    }

    public void Save(GameData gameData)
    {
        //string fullpath
    }
}
