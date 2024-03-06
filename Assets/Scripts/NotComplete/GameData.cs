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
    public Vector3 playerPositionOnDay1Scene;
    public Vector3 playerPositionOnDay2Scene;
    public Vector3 playerPositionOnSchoolScene;
    public Vector3 playerPositionOnDorm;
    public Vector3 playerPositionOnHome;
    public Vector3 playerPositionOnHospital;
    public Vector3 playerPositionOnLastChapter;
    public Vector3 playerPositionOnNightSchool;
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
        this.playerPositionOnDay1Scene = new Vector3(-1010.38f, 24.6399994f, -4.36000013f);
        this.playerPositionOnDay2Scene = new Vector3(-708.817993f, 0.699999988f, 66.9599991f);
        this.playerPositionOnDorm = new Vector3(216.103104f, 4.26800013f, 7.28353834f);
        this.playerPositionOnHome = new Vector3(5.6500001f, 0.560000002f, -4.21999979f);
        this.playerPositionOnHospital = new Vector3(143.699997f, 0f, -7.0999999f);
        this.playerPositionOnLastChapter = new Vector3(-1005.69f, 32.7999992f, -4.8499999f);
        this.playerPositionOnNightSchool = new Vector3(-1010.56f, 24.6000004f, -4.23000002f);
        this.playerPositionOnSchoolScene = new Vector3(-726.549988f, 0.689999998f, 66.7969971f);
    }

    public void LoadPosition(string nameScene)
    {
        switch (nameScene)
        {
            case "Day1_SchoolScene":
                this.playerPosition = this.playerPositionOnDay1Scene;
                break;
            case "Day2_SchoolScene 1":
                this.playerPosition = this.playerPositionOnDay2Scene;
                break;
            case "Dorm":
                this.playerPosition = this.playerPositionOnDorm;
                break;
            case "Home":
                this.playerPosition = this.playerPositionOnHome;
                break;
            case "HospitalScene":
                this.playerPosition = this.playerPositionOnHospital;
                break;
            case "Last_Chapter":
                this.playerPosition = this.playerPositionOnLastChapter;
                break;
            case "Night_School Scene":
                this.playerPosition = this.playerPositionOnNightSchool;
                break;
            case "SchoolScene":
                this.playerPosition = this.playerPositionOnSchoolScene;
                break;
            default: 
                break;
        }
    }

    public void SavePosition(string nameScene, Vector3 playerPosition)
    {
        switch (nameScene)
        {
            case "Day1_SchoolScene":
                this.playerPositionOnDay1Scene = playerPosition;
                break;
            case "Day2_SchoolScene 1":
                this.playerPositionOnDay2Scene = playerPosition;
                break;
            case "Dorm":
                this.playerPositionOnDorm = playerPosition;
                break;
            case "Home":
                this.playerPositionOnHome = playerPosition;
                break;
            case "HospitalScene":
                this.playerPositionOnHospital = playerPosition;
                break;
            case "Last_Chapter":
                this.playerPositionOnLastChapter = playerPosition;
                break;
            case "Night_School Scene":
                this.playerPositionOnNightSchool = playerPosition;
                break;
            case "SchoolScene":
                this.playerPositionOnSchoolScene = playerPosition;
                break;
            default:
                break;
        }
    }
 }
