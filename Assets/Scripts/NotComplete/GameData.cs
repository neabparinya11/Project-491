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
    public List<TaskComponent> listTaskComponent;
    public SerialiazableDictionary<string, bool> dictBoxItem;
    public SerialiazableDictionary<string, bool> dictDoorAction;
    public SerialiazableDictionary<string, bool> dictQuestItem;
    public SerialiazableDictionary<string, bool> dictCutscene;
    public GameData()
    {
        this.playerName = string.Empty;
        this.playerPosition = new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
        this.enemyPosition = Vector3.zero;
        this.enemyLevel = 1;
        this.percentageHealth = 100.0f;
        this.currentScene = string.Empty;
        //this.listFoodItem = new List<FoodItem>();
        //this.listQuestItem = new List<QuestionItem>();
        this.listQuestItem = new List<QuestionItem>();
        this.listFoodItem = new List<FoodItem>();
        this.listTaskComponent = new List<TaskComponent>();
        this.dictBoxItem = new SerialiazableDictionary<string, bool>();
        this.dictDoorAction = new SerialiazableDictionary<string, bool>();
        this.dictCutscene = new SerialiazableDictionary<string, bool>() { 
            { "TeacherCutscene", true }, 
            { "PoliceCutscene", true }, 
            { "PreawHospital", true },
            { "PreawMother", true },
            { "PreawEx2", true}
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
