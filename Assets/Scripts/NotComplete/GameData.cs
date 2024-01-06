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
    public List<FoodItem> listFoodItem;
    public List<QuestionItem> listQuestItem;
    public Dictionary<string, bool> allBoxItem;
    public GameData()
    {
        this.playerName = string.Empty;
        this.playerPosition = new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
        this.enemyPosition = Vector3.zero;
        this.enemyLevel = 1;
        this.percentageHealth = 0;
        this.currentScene = string.Empty;
        this.listFoodItem = new List<FoodItem>();
        this.listQuestItem = new List<QuestionItem>();
        this.allBoxItem = new Dictionary<string, bool>();
    }

    private Vector3 setStartPositionOnScene(string nameScene)
    {
        switch (nameScene)
        {
            case "Day_SchoolScene":
                return new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
                break;
        }
        return Vector3.zero;
    }
 }
