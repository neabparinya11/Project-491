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
    public Dictionary<string, bool> dictBoxItem;
    public Dictionary<string, bool> dictDoorAction;
    public Dictionary<string, bool> dictQuestItem;
    public Dictionary<string, bool> dictCutscene;
    public GameData()
    {
        this.playerName = string.Empty;
        this.playerPosition = new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
        this.enemyPosition = Vector3.zero;
        this.enemyLevel = 1;
        this.percentageHealth = 100.0f;
        this.currentScene = string.Empty;
        this.listFoodItem = new List<FoodItem>();
        this.listQuestItem = new List<QuestionItem>();
        this.dictBoxItem = new Dictionary<string, bool>();
        this.dictDoorAction = new Dictionary<string, bool>();
        this.dictCutscene = new Dictionary<string, bool>() { 
            { "TeacherCutscene", true }, 
            { "PoliceCutscene", true }, 
            { "PreawHospital", true },
            { "PreawMother", true }
        };
    }

    public void setStartPositionOnScene(string nameScene)
    {
        switch (nameScene)
        {
            case "Day_SchoolScene":
                this.playerPosition = new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
                break;
            case "HospitalScene":
                this.playerPosition = new Vector3(-32.7900009f, 0, -16.5499992f);
                break;
            case "":
                this.playerPosition = Vector3.zero;
                break;
        }
    }
 }
