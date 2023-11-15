using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] float patrolSpeed, chaseSpeed;
    [SerializeField] float detectionRange;
    [SerializeField] float attackRange;
    [SerializeField] Transform[] listWaypoint;

    protected int currentWaypoint = 0;
    protected Animator animator;
    protected EnemyState currentState;
    protected int level;
    protected enum EnemyState
    {
        Patrol, Investigate, Chase, Attacked
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        currentState = EnemyState.Patrol;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Investigate:
                Investigate();
                break;
            case EnemyState.Chase:
                Chase();
                break;
            case EnemyState.Attacked:
                Attack();
                break;
        }
    }

    void Patrol()
    {
        agent.destination = listWaypoint[currentWaypoint].position;
        if (agent.remainingDistance < 0.1f)
        {
            currentWaypoint = (currentWaypoint + 1) % listWaypoint.Length;
        }
        DetectPlayer();
    }

    void Investigate()
    {

        DetectPlayer();
    }

    void Chase()
    {
        agent.destination = player.position;
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            currentState = EnemyState.Attacked;
            agent.isStopped = true;
        }
        if (Vector3.Distance(transform.position, player.position) > 20f)
        {
            currentState = EnemyState.Patrol;
            agent.isStopped = false;
        }
    }

    void DetectPlayer()
    {
        Vector3 DirectionToPlayer = (player.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, DirectionToPlayer, out hit, detectionRange))
        {
            if (hit.collider.CompareTag("Player"))
            {
                currentState = EnemyState.Chase;
            }
        }
    }

    void Attack()
    {
        //HealthController.instance.DecreaseHealth(20);
        currentState = EnemyState.Chase;
    }
    public void IncreaseLevel(int _value)
    {
        level += _value;
    }

    public void DecreaseLevel(int _value)
    {
        level -= _value;
    }

    public void Teleport(Vector3 _newPosition)
    {
        this.transform.position = _newPosition;
    }

    public int getCurrentStateEnemy()
    {
        return (int)this.currentState;
    }
}
