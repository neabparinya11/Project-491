using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    [Header("Stamina Parameter")]
    [SerializeField] float _playerMaxStamina = 100.0f;
    [SerializeField] float _staminaCost = 20.0f; 
    [HideInInspector] bool isStaminaRegenerated = true;
    float _playerStamina = 100.0f;

    [Header("Stamina UI Element")]
    [SerializeField] Image staminaProgressUI = null;
    [SerializeField] CanvasGroup sliderCanvasGroup = null;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
