using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    public static StaminaController instance;
    public float playerStamina = 100.0f;
    [SerializeField] private float playerMaxStamina = 100.0f;
    [SerializeField] private float jumpCost = 30.0f;
    [HideInInspector] public bool regenrate = true;
    [HideInInspector] public bool wasSprint = false;
    [Range(0, 50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;

    [SerializeField] private int slowSpeed = 4;
    [SerializeField] private int normalSpeed = 8;

    [SerializeField] private Image staminaProgressUI;
    [SerializeField] private CanvasGroup sliderCanvasGroup;

    //public PlayerMovmentsScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(wasSprint);
        if (!wasSprint)
        {
            if (playerStamina <= playerMaxStamina - 0.01f)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if (playerStamina >= playerMaxStamina)
                {
                    sliderCanvasGroup.alpha = 0;
                    PlayerMovmentsScript.instance.SetRunSpeed(normalSpeed);
                    regenrate = true;
                }
            }
        }
        else
        {
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);
            if (playerStamina <= 0)
            {
                wasSprint = false;
                PlayerMovmentsScript.instance.isSprint = false;
            }
        }
    }

    public void Sprinting()
    {
        if (regenrate)
        {
            wasSprint = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0)
            {
                sliderCanvasGroup.alpha = 0;
                PlayerMovmentsScript.instance.SetRunSpeed(slowSpeed);
                regenrate = false;
            }
        }
    }
  
    public void StaminaJump()
    {
        if (playerStamina >= (playerStamina * jumpCost / playerMaxStamina))
        {
            playerStamina -= jumpCost;
            //playerScript.PlayerJump();
            PlayerMovmentsScript.instance.PlayerJump();
            UpdateStamina(1);
        }
    }

    public void UpdateStamina(int _value)
    {
        staminaProgressUI.fillAmount = playerStamina / playerMaxStamina;
        if (_value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;
        }
    }

    public void IncreaseStamina(float _value)
    {
        playerStamina += _value;
    }
}
