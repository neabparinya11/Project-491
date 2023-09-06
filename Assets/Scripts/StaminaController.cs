using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
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

    private PlayerMovmentsScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponent<PlayerMovmentsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!wasSprint)
        {
            if (playerStamina <= playerMaxStamina - 0.01f)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                UpdateStamina(1);

                if (playerStamina >= playerMaxStamina)
                {
                    playerScript.SetRunSpeed(normalSpeed);
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
                playerScript.isSprint = false;
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
                playerScript.SetRunSpeed(slowSpeed);
                regenrate = false;
            }
        }
    }
  
    public void StaminaJump()
    {
        if (playerStamina >= (playerStamina * jumpCost / playerMaxStamina))
        {
            playerStamina -= jumpCost;
            playerScript.PlayerJump();
            UpdateStamina(1);
        }
    }

    public void UpdateStamina(int _value)
    {
        staminaProgressUI.fillAmount = playerStamina / playerMaxStamina;
    }
}
