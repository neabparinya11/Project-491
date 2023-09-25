using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPlayerManager : MonoBehaviour
{
    [SerializeField] float playerStamina = 100.0f;
    [SerializeField] float maxStamina = 100.0f;
    [Range(0, 50)][SerializeField] private float staminaDrain = 5.0f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 5.0f;
    [HideInInspector] public bool isRegenerate = true;
    [HideInInspector] public bool isSprint = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
