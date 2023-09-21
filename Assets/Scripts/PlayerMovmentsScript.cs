using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovmentsScript : MonoBehaviour
{
    public static PlayerMovmentsScript instance;
    float movementSpeed = 1.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] float cruchSpeed = .2f;
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    //[HideInInspector] public StaminaController staminaController;
    private Rigidbody rb;
    private Animator animations;
    //MovementState movementState = MovementState.idle;
    private float Horizontal;
    public bool isSprint;
    
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
        //staminaController = GetComponent<StaminaController>();
    }

    public void SetRunSpeed(float _speed)
    {
        movementSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void PlayerJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 3f, 0);
    }

    private void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(Horizontal * movementSpeed, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space) && CheckIsGround())
        {
            //rb.velocity = new Vector3(rb.velocity.x, 3f, 0);
            StaminaController.instance.StaminaJump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckIsGround())
        {
            //staminaController.Sprinting();
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

        if (rb.velocity.y > 0.0f)
        {
            
            movementState = MovementState.jump;
        }
        animations.SetInteger("Anim State", (int)movementState);
    }

    public void onPlayerAttacked(float _value)
    {
        HealthController.instance.DecreaseHealth(_value);
    }

}
