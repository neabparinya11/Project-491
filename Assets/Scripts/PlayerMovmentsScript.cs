using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovmentsScript : MonoBehaviour, IDataPersistances
{
    public static PlayerMovmentsScript instance;
    float movementSpeed = 1.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] float cruchSpeed = .2f;
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [Header("Damage overlay")]
    [SerializeField] Image overlay;
    [SerializeField] float duration;
    [SerializeField] float fadeSpeed;

    private Rigidbody rb;
    private Animator animations;
    private float durationTimer;
    //MovementState movementState = MovementState.idle;
    private float Horizontal;
    public bool isSprint;
    public bool isHidden = false;
    public bool disable = false;
    // state 0 = idle, state 1 = walking, state 2 = sprint, state 3 = crunch, state 4 = jump, state 5 = fall, state 6 = land
    // priority idle << walking << sprint
    enum MovementState
    {
        idle, walking, sprint, cruch, jump, fall, land
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<Animator>();
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    public void SetRunSpeed(float _speed)
    {
        movementSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (disable)
        {
            return;
        }
        Movement();
        DamageOverlay();
        if (isHidden)
        {
            Hidding();
        }
        else
        {
            UnHidding();
        }
    }

    public void PlayerJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 3f, 0);
    }

    public void StopPlayer()
    {
        disable = true;
        rb.velocity = Vector3.zero;
        Horizontal = 0.0f;
        AnimationUpdates();
    }

    public void ContinuePlayer()
    {
        disable = false;
    }
    private void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(Horizontal * movementSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckIsGround())
        {
            isSprint = true;
            if (rb.velocity.x != 0.0f)
            {
                StaminaController.instance.wasSprint = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && CheckIsGround())
        {
            isSprint = false;
            StaminaController.instance.wasSprint = false;
        }
        AnimationUpdates();
    }

    private bool CheckIsGround()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, groundLayer);
    }
    private void AnimationUpdates()
    {
        MovementState movementState;
        if (Horizontal > 0.0f)
        {
            if (isSprint)
            {
                movementState = MovementState.sprint;
                movementSpeed = sprintSpeed;
            }
            else
            {
                movementState = MovementState.walking;
                movementSpeed = walkSpeed;
            }
            
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }else if (Horizontal < 0.0f)
        {
            if (isSprint)
            {
                movementState = MovementState.sprint;
                movementSpeed = sprintSpeed;
            }
            else
            {
                movementState = MovementState.walking;
                movementSpeed = walkSpeed;
            }
            
            this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        else
        {
            movementState = MovementState.idle;
        }

        animations.SetInteger("Anim State", (int)movementState);
    }

    public void onPlayerAttacked(float _value)
    {
        HealthController.instance.DecreaseHealth(_value);
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 1);
    }

    private void DamageOverlay()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    private void Hidding()
    {
         gameObject.SetActive(false);
    }

    private void UnHidding()
    {
         gameObject.SetActive(true);
    }

    public void SaveData(ref GameData gameData)
    {
        
    }

    public void LoadData(GameData gameData)
    {
        
    }
}
