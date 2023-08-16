using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Transform> destination;
    [SerializeField] Animator animator;
    [SerializeField] float walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, deathTime;
    [SerializeField] bool walking, chasing;
    [SerializeField] Transform player;
    [SerializeField] int destinationAmount;
    [SerializeField] Vector3 rayCastOffSet;
    [SerializeField] string deathScene;
    [SerializeField] Animator animatons;
    [SerializeField] AudioSource walkingSound;

    // 1 = normal, 2 = hard, 3 = permadeath
    int levelEnemy = 1;
    Transform currentDestination;
    Vector3 dest;
    int randomNumber1;
    float enemyDistance;
    private void Start()
    {
        walking = true;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        enemyDistance = Vector3.Distance(player.position, this.transform.position);
        Debug.DrawRay(transform.position + rayCastOffSet, direction, Color.green);
        if (Physics.Raycast(transform.position + rayCastOffSet, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine(stayIdle());
                StopCoroutine(chaseRoutine());
                StartCoroutine(chaseRoutine());
                chasing = true;
            }
        }
        if (chasing == true)
        {
            dest = player.position;
            agent.destination = dest;
            agent.speed = chaseSpeed;
            if (enemyDistance <= catchDistance)
            {
                //player.gameObject.SetActive(false);
                //StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
        if (walking == true)
        {
            dest = currentDestination.position;
            agent.destination = dest;
            agent.speed = walkSpeed;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
            }
        }
    }
    IEnumerator stayIdle()
    {
        idleTime = UnityEngine.Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = UnityEngine.Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene(deathScene);
    }
}
