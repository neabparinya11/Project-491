using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour, IDataPersistances
{
    private static LoadScene instance;
    //[SerializeField] private string targetSceneName;
    [SerializeField] private float transitionTime;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] private bool usePlayerPostion;

    private string sceneName;

    private void Start()
    {
        instance = this;
    }

    public static LoadScene GetInstance()
    {
        return instance;
    }
    public void LoadTargetScene(string targetSceneNme)
    {
        this.sceneName = targetSceneNme;
        StartCoroutine(LoadNextScene(targetSceneNme));
    }

    public void QuiteGame()
    {
        //#if UNITY_EDITOR
        //        EditorApplication.isPlaying = false;
        //#else
        Application.Quit();
//#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuiteGame();
        }  
    }

    private IEnumerator LoadNextScene(string targetSceneName)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (usePlayerPostion)
        {
            switch (targetSceneName)
            {
                case "Day_SchoolScene":
                    this.player.transform.position = new Vector3(-1008.87f, 24.7600002f, -4.23000002f);
                    break;
                case "HospitalScene":
                    this.player.transform.position = new Vector3(-32.7900009f, 0, -16.5499992f);
                    break;
                default:
                    this.player.transform.position = Vector3.zero; 
                    break;
            }
        }
        
        SceneManager.LoadSceneAsync(targetSceneName);
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.currentScene = this.sceneName;
    }

    public void LoadData(GameData gameData)
    {
        this.sceneName = gameData.currentScene;
    }
}
