using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class LoadScene : MonoBehaviour, IDataPersistances
{
    private static LoadScene instance;
    //[SerializeField] private string targetSceneName;
    [SerializeField] private float transitionTime;
    [SerializeField] private Animator anim;
    [SerializeField] private UnityEvent OnPlayerLoadScene;

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
        OnPlayerLoadScene?.Invoke();
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
