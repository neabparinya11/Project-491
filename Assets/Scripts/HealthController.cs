using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController instance;
    [SerializeField] Image _healthBar;
    [SerializeField] string deathScene;
    public float percentageHealth = 100.0f;
    public float maxPercentageHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        percentageHealth = 100.0f;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentageHealth <= 0)
        {
            SceneManager.LoadScene(deathScene);
        }
        UpdateHealth();
    }

    public void DecreaseHealth(float _value)
    {
        percentageHealth -= _value;
    }

    public void IncreaseHealth(float _value)
    {
        percentageHealth += _value;
    }

    public void UpdateHealth()
    {
        _healthBar.fillAmount = percentageHealth/ maxPercentageHealth;
    }
}
