using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string _playerName { get; set; }
    public Vector3 _playerPosition { get; set; }
    public Vector3 _enemyPosition { get; set; }
    public int _enemyLevel { get; set; }
    public GameData()
    {
        this._playerName = string.Empty;
        this._playerPosition = Vector3.zero;
        this._enemyPosition = Vector3.zero;
        this._enemyLevel = 1;
    }
}
