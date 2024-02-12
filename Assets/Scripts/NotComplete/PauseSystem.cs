using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] Behaviour playerScript;
    [SerializeField] Behaviour enemyScript;

    public static PauseSystem instance;

    private void Start()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            if (playerScript != null)
            {
                playerScript.enabled = false;
            }
            if (enemyScript != null)
            {
                enemyScript.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ContinueGame();
            if (playerScript != null)
            {
                playerScript.enabled = true;
            }
            if (enemyScript != null)
            {
                enemyScript.enabled = true;
            }
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
