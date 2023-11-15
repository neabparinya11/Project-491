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
    int levelEnemy = 1;
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
        walkingSound.enabled = false;
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
                //StoryController.instance.SetChasingBoolean(true);
                animations.SetInteger("state", (int)EnemyState.run);
            }
        }
        switch (levelEnemy)
        {
            case 1:
                EnemyLevel1();
                break;
            case 2:
                EnemyLevel2();
                break;
            case 3:
                EnemyLevel3();
                break;
            default: break;
        }

    }

    private void EnemyLevel3()
    {
        throw new NotImplementedException();
        if (chasing == true)
        {
            dest = player.position;
            agent.destination = dest;
            agent.speed = chaseSpeed;
            if (enemyDistance <= catchDistance)
            {
                agent.isStopped = true;
                animations.SetInteger("state", (int)EnemyState.attack);

            }
        }
    }

    private void EnemyLevel2()
    {
        throw new NotImplementedException();
    }

    public void stopChase()
    {
        walking = true;
        walkingSound.enabled = true;
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
        //StoryController.instance.SetChasingBoolean(false);
        chasing = false;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
    }
    IEnumerator attackedRoutine()
    {
        attacked = true;
        yield return new WaitForSeconds(attackedTime);
        //agent.isStopped = false;
        attacked = false;
    }
    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(deathTime);
        SceneManager.LoadScene(deathScene);
    }

    public void EnemyLevel1()
    {
        if (chasing == true)
        {
            dest = player.position;
            if (transform.position.x - dest.x > 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
            if (transform.position.x - dest.x < 0)
            {
                this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            agent.destination = dest;
            agent.speed = chaseSpeed;

            if (enemyDistance <= catchDistance)
            {
                //agent.isStopped = true;
                animations.SetInteger("state", (int)EnemyState.attack);
                if (!attacked)
                {
                    StartCoroutine(attackedRoutine());
                    PlayerMovmentsScript.instance.onPlayerAttacked(20);
                }
                chasing = true;
                StopCoroutine(attackedRoutine());
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
    public void SetStart()
    {
        walking = true;
        walkingSound.enabled = false;
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        currentDestination = destination[randomNumber1];
        animations = GetComponent<Animator>();
    }

    public void SetNewPosition(Vector3 _newPosition)
    {
        this.transform.position = _newPosition;
    }
}