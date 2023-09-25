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
    [SerializeField] float attackedTime;
    [SerializeField] float walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, deathTime;
    public bool walking, chasing, attacking;
    [SerializeField] Transform player;
    [SerializeField] int destinationAmount;
    [SerializeField] Vector3 rayCastOffSet;
    [SerializeField] string deathScene;
    protected Animator animations;
    [SerializeField] AudioSource walkingSound;
   
    // 1 = normal, 2 = hard, 3 = permadeath
    int levelEnemy = 3;
    Transform currentDestination;
    Vector3 dest;
    int randomNumber1;
    float enemyDistance;
    bool attacked = false;

    enum EnemyState
    {
        idle, walk, run, attack
    }
    private void Start()
    {
        walking = true;
        walkingSound.enabled = true;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
        animations = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        RaycastHit hit;
        enemyDistance = Vector3.Distance(player.position, this.transform.position);
        if (Physics.Raycast(transform.position + rayCastOffSet, direction, out hit, sightDistance))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                walking = false;
                walkingSound.enabled = false;
                StopCoroutine(stayIdle());
                StopCoroutine(chaseRoutine());
                StartCoroutine(chaseRoutine());
                chasing = true;
                animations.SetInteger("state", (int)EnemyState.run);
            }
        }
        switch (levelEnemy)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                EnemyLevel3();
                break;
            default: break;
        }

    }

    public void stopChase()
    {
        walking = true;
        chasing = false;
        StopCoroutine(chaseRoutine());
        currentDestination = destination[UnityEngine.Random.Range(0, destinationAmount)];
    }

    public void LevelEnemyIncress()
    {
        levelEnemy += 1;
    }

    public void ResetLevelEnemy()
    {
        levelEnemy = 1;
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
    IEnumerator attackedRoutine()
    {
        attacked = true;
        yield return new WaitForSeconds(attackedTime);
        attacked = false;
    }
    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene(deathScene);
    }

    public void EnemyLevel3()
    {
        if (chasing == true)
        {
            dest = player.position;
            agent.destination = dest - new Vector3(catchDistance - 0.5f, .0f, .0f);
            agent.speed = chaseSpeed;

            if (enemyDistance <= catchDistance)
            {
                animations.SetInteger("state", (int)EnemyState.attack);
                if (!attacked)
                {
                    StartCoroutine(attackedRoutine());
                    HealthController.instance.DecreaseHealth(20);   
                }
                //if (!attacked)
                //{
                //    if (leftHand.gameObject.tag == "Enemy")
                //    {
                //        attacked = true;
                        
                //        HealthController.instance.DecreaseHealth(25);
                //    }
                //    chasing = true;
                //}

            }
        }
        if (walking == true)
        {
            dest = currentDestination.position;
            agent.destination = dest;
            agent.speed = walkSpeed;
            walkingSound.enabled = true;
            animations.SetInteger("state", (int)EnemyState.walk);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0;
                StopCoroutine("stayIdle");
                StartCoroutine("stayIdle");
                walking = false;
                animations.SetInteger("state", (int)EnemyState.idle);
                walkingSound.enabled = false;
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other.gameObject.tag);
    //}
}
