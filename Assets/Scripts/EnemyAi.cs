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
    [SerializeField] AudioSource walkingSound;

    // 1 = normal, 2 = hard, 3 = permadeath
    int levelEnemy = 1;
    Transform currentDestination;
    Vector3 dest;
    int randomNumber1;
    

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
        if (Physics.Raycast(transform.position + rayCastOffSet, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                StopCoroutine("stayIdle");
                StopCoroutine("chaseRoutine");
                StartCoroutine("chaseRoutine");
                chasing = true;
            }
        }
        if (chasing)
        {
            dest = player.position;
            agent.destination = dest;
            agent.speed = chaseSpeed;
            if (agent.remainingDistance <= catchDistance)
            {
                player.gameObject.SetActive(false);
                StartCoroutine(deathRoutine());
                chasing = false;
            }
        }
        if (walking)
        {
            dest = currentDestination.position;
            agent.destination = dest;
            agent.speed = walkSpeed;
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0;
                walking = false;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
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
