using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovmentsScript : MonoBehaviour
{
    float movementSpeed = 10.0f;
    [SerializeField] float sprintSpeed = 10.0f;
    [SerializeField] float cruchSpeed = .2f;
    [SerializeField] float walkSpeed = 1.0f;
    private Rigidbody rb;
    private Animator animations;
    MovementState movementState = MovementState.idle;
    float Horizontal;
    bool isRight = true;
    
    // state 0 = idle, state 1 = walking, state 2 = sprint, state 3 = crunch
    // priority idle << walking << sprint
    enum MovementState
    {
        idle, walking, sprint, cruch
    }

    void MovementStateHandle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementState = MovementState.sprint;
            movementSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementState = MovementState.idle;
            movementSpeed = walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            movementState = MovementState.cruch;
            movementSpeed = cruchSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            movementState = MovementState.walking;
            movementSpeed = walkSpeed;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (movementState != MovementState.sprint)
            {
                movementState = MovementState.walking;
                movementSpeed = walkSpeed;
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movementState = MovementState.idle;
            movementSpeed = walkSpeed;
        }
        //movementState = MovementState.idle;
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
        MovementStateHandle();
        Movement();
        Debug.Log(movementState);
    }

    private void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (Horizontal * movementSpeed, 0, 0);

        // Check direction of character
        if (Horizontal > 0)
        {
            isRight = true;
        }
        if (Horizontal < 0)
        {
            isRight = false;
        }

        // Check value horizontal to play animation
        if (Horizontal != 0)
        {
            animations.SetInteger("Anim State", (int)movementState);
        }

        // Rotation character
        if (isRight)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        }

    }
}
