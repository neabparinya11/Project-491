using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovmentsScript : MonoBehaviour
{
    float movementSpeed = 1.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] float cruchSpeed = .2f;
    [SerializeField] float walkSpeed = 1.0f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody rb;
    private Animator animations;
    //MovementState movementState = MovementState.idle;
    private float Horizontal;
    private bool isSprint;
    
    // state 0 = idle, state 1 = walking, state 2 = sprint, state 3 = crunch, state 4 = jump, state 5 = fall, state 6 = land
    // priority idle << walking << sprint
    enum MovementState
    {
        idle, walking, sprint, cruch, jump, fall, land
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animations = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (Horizontal * movementSpeed, rb.velocity.y, 0);
        // Check direction of character
        //if (Horizontal > 0)
        //{
        //    isRight = true;
        //}
        //if (Horizontal < 0)
        //{
        //    isRight = false;
        //}

        // Check value horizontal to play animation
        //if (Horizontal != 0)
        //{
        //    animations.SetInteger("Anim State", (int)movementState);
        //}

        // Rotation character
        //if (isRight)
        //{
        //    this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        //}
        //else
        //{
        //    this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && CheckIsGround())
        {
            rb.velocity = new Vector3(rb.velocity.x, 3f, 0);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && CheckIsGround())
        {
            isSprint = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && CheckIsGround())
        {
            isSprint = false;
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

        if (rb.velocity.y > 0.1f)
        {
            movementState = MovementState.jump;
        }
        animations.SetInteger("Anim State", (int)movementState);
    }
}
