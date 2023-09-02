using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] LayerMask groundLayerMask;
    private Rigidbody rigidbody;
    private Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
