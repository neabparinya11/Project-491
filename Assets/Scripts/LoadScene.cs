using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private static LoadScene instance;
    //[SerializeField] private string targetSceneName;
    [SerializeField] private float transitionTime;
    [SerializeField] private Animator anim;

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
}
