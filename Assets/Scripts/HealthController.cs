using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField] GameObject health1, health2, health3, health4, health5;
    [SerializeField] string deathScene;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        health1.gameObject.SetActive(true);
        health2.gameObject.SetActive(true);
        health3.gameObject.SetActive(true);
        health4.gameObject.SetActive(true);
        health5.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (health)
        {
            case 5:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(true);
                break;
            case 4:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(true);
                health5.gameObject.SetActive(false);
                break;
            case 3:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(true);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            case 2:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(true);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            case 1:
                health1.gameObject.SetActive(true);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                break;
            default:
                health1.gameObject.SetActive(false);
                health2.gameObject.SetActive(false);
                health3.gameObject.SetActive(false);
                health4.gameObject.SetActive(false);
                health5.gameObject.SetActive(false);
                SceneManager.LoadScene(deathScene);
                break;
        }
    }
}
