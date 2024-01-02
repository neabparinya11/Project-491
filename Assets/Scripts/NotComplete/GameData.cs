using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public string playerName;
    public Vector3 playerPosition;
    public Vector3 enemyPosition;
    public int enemyLevel;
    public float percentageHealth;
    public string currentScene;
    public GameData()
    {
        this.playerName = string.Empty;
        this.playerPosition = new Vector3(-922.75f, 13.29f, -7.6f);
        this.enemyPosition = Vector3.zero;
        this.enemyLevel = 1;
        this.percentageHealth = 0;
        this.currentScene = string.Empty;
    }

    private Vector3 setStartPositionOnScene(string nameScene)
    {
        return Vector3.zero;
    }
 }
