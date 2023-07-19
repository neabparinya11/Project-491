using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [Header("Initialize")]
    [SerializeField] Transform playerTarget;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LayerMask isPlayer, isGround;

    [Header("Setting Enemy")]
    [SerializeField] float walkingRange;
    Vector3 walkingPosition;
    [SerializeField] float walkingSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float signRange, attackRange;

    bool walkPointSet;

    bool isWalking = false;
    bool isAttacked = false;
    bool playerInSignRange, playerInAttackRange;
    private void Awake()
    {
        playerTarget = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        playerInSignRange = Physics.CheckSphere(transform.position, signRange, isPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, isPlayer);

        if (!playerInSignRange && !playerInAttackRange) Patrolling();
        if (playerInSignRange && !playerInAttackRange) Hunting();
        if (playerInSignRange && playerInAttackRange) Attack();

    }

    private void Patrolling()
    {

    }

    private void Attack()
    {

    }

    private void Hunting()
    {

    }

}
