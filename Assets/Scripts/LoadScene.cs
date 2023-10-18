using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] string targetSceneName;
    
    public void LoadTargetScene()
    {
        Debug.Log(targetSceneName);
        SceneManager.LoadScene(targetSceneName);
    }

    public void QuiteGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quite();
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        LoadTargetScene();
    }
}
