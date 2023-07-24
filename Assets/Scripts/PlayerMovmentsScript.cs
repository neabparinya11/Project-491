using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovmentsScript : MonoBehaviour
{
    float movementSpeed = 10.0f;
    [SerializeField] float sprintSpeed = 200.0f;
    [SerializeField] float cruchSpeed = .2f;
    [SerializeField] float walkSpeed = 10.0f;
    Rigidbody rb;

    float Horizontal;
    bool isRight = true;
    private Animator animations;

    // state 0 = idle, state 1 = walking, state 2 = sprint, state 3 = crunch
    enum MovementState
    {
        idle, walking, sprint, cruch
    }

    MovementState movementState = MovementState.idle;

    void MovementStateHandle()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementState = MovementState.sprint;
            movementSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementState = MovementState.walking;
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

        movementState = MovementState.idle;
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
    }

    private void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (Horizontal * movementSpeed, 0, 0);
        if (Horizontal > 0)
        {
            isRight = true;
        }
        if (Horizontal < 0)
        {
            isRight = false;
        }
        switch (movementState)
        {
            case MovementState.sprint:
                animations.SetInteger("Anim_State", 2);
                break;
            case MovementState.walking:
                animations.SetInteger("Anim_State", 1);
                break;
            case MovementState.cruch:

                break;
            default:
                animations.SetInteger("Anim_State", 0);
                break;

        }
        if (isRight)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    void SprintMovement()
    {

    }

    void CruchMovement()
    {

    }
}
