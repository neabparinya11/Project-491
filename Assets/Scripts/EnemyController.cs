using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] float walkingSpeed, chaseSpeed;
    protected Animator animator;
    protected int level;
    enum EnemyState
    {
        idle, walk, run, attack
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseLevel(int _value)
    {
        level += _value;
    }

    public void DecreaseLevel(int _value)
    {
        level -= _value;
    }
}
