using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] List<Transform> destination;
    [SerializeField] float attackedTime;
    [SerializeField] float walkSpeed, chaseSpeed, idleTime, minIdleTime, maxIdleTime, sightDistance, catchDistance, chaseTime, minChaseTime, maxChaseTime, deathTime, respawnTime;
    public bool walking, chasing, attacking;
    [SerializeField] Transform player;
    [SerializeField] int destinationAmount;
    [SerializeField] Vector3 rayCastOffSet;
    [SerializeField] string deathScene;
    protected Animator animations;
    [SerializeField] AudioSource walkingSound;
    [SerializeField] AudioClip backgroundAudio;
    [SerializeField] AudioClip chasingAudio;
    protected float multiDamage = 0;

    // 1 = normal, 2 = hard, 3 = permadeath
    private int levelEnemy = 1;
    private Transform currentDestination;
    private Vector3 dest;
    private int randomNumber1;
    private float enemyDistance;
    private bool attacked = false;
    [SerializeField] private List<Transform> canCurrent = new List<Transform>();

    enum EnemyState
    {
        idle, walk, run, attack
    }
    private void Start()
    {
        walking = true;
        walkingSound.enabled = false;
        animations = GetComponent<Animator>();
        FindNodeInCurrentPosition(this.transform.position);
        randomNumber1 = UnityEngine.Random.Range(0, canCurrent.Count);
        currentDestination = canCurrent[randomNumber1];
        StartCoroutine(RandomSpawn());
    }

    private void Update()
    {
        Investigate();
        Walking();
        ChasingAndAttacked();
        
        switch (levelEnemy)
        {
            case 1:
                multiDamage = 1;
                break;
            case 2:
                multiDamage = 2;
                break;
            case 3:
                multiDamage = 100;
                break;
            default: break;
        }

    }

    /// <summary>
    /// This function is serching player in around enemy
    /// </summary>
    protected void Investigate()
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
                AudioManager.GetInstance().ChangeBackgroundMusic(chasingAudio);
                animations.SetInteger("state", (int)EnemyState.run);
            }
        }
    }

    /// <summary>
    /// This fuction is stop chasing routine of enemy
    /// </summary>
    public void stopChase()
    {
        walking = true;
        walkingSound.enabled = true;
        chasing = false;
        StopCoroutine(chaseRoutine());
        currentDestination = canCurrent[UnityEngine.Random.Range(0, canCurrent.Count)];
    }

    /// <summary>
    /// Increase level or phase of enemy 
    /// </summary>
    public void LevelEnemyIncress()
    {
        levelEnemy += 1;
    }

    /// <summary>
    /// Decrease level or phase of enemy
    /// </summary>
    public void ResetLevelEnemy()
    {
        levelEnemy = 1;
    }

    IEnumerator stayIdle()
    {
        idleTime = UnityEngine.Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);
        walking = true;
        randomNumber1 = UnityEngine.Random.Range(0, canCurrent.Count);
        currentDestination = canCurrent[randomNumber1];
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = UnityEngine.Random.Range(minChaseTime, maxChaseTime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        //StoryController.instance.SetChasingBoolean(false);
        chasing = false;
        AudioManager.GetInstance().ChangeBackgroundMusic(backgroundAudio);
        randomNumber1 = UnityEngine.Random.Range(0, canCurrent.Count);
        currentDestination = canCurrent[randomNumber1];
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

    public void ChasingAndAttacked()
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
                    PlayerMovmentsScript.instance.onPlayerAttacked(20*multiDamage);
                }
                chasing = true;
                StopCoroutine(attackedRoutine());
            }
        }
        
    }

    /// <summary>
    /// 
    /// </summary>
    protected void Walking()
    {
        if (walking == true)
        {
            //randomNumber1 = UnityEngine.Random.Range(0, canCurrent.Count);
            //currentDestination = canCurrent[randomNumber1];

            dest = currentDestination.position;
            agent.destination = dest;
            agent.speed = walkSpeed;
            walkingSound.enabled = true;
            animations.SetInteger("state", (int)EnemyState.walk);
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                agent.speed = 0;
                StopCoroutine(stayIdle());
                StartCoroutine(stayIdle());
                walking = false;
                animations.SetInteger("state", (int)EnemyState.idle);
                walkingSound.enabled = false;
            }
        }
    }

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
        FindNodeInCurrentPosition(_newPosition);
        agent.Warp(_newPosition);
        randomNumber1 = UnityEngine.Random.Range(0, canCurrent.Count);
        currentDestination = canCurrent[randomNumber1];
    }

    public IEnumerator RandomSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30.0f);
            if (chasing == false && agent.remainingDistance <= 0)
            {
                randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
                SetNewPosition(destination[randomNumber1].position);
            }
        }
        
    }

    public void FindNodeInCurrentPosition(Vector3 _currentPosition)
    {
        canCurrent.Clear();
        foreach (Transform transformPosition in destination)
        {
            if (_currentPosition.y <= transformPosition.position.y + 1.0f && _currentPosition.y >= transformPosition.position.y - 1.0f )
            {
                canCurrent.Add(transformPosition);
            }
        }
    }

    public void RandomPosition()
    {
        randomNumber1 = UnityEngine.Random.Range(0, destinationAmount);
        SetNewPosition(destination[randomNumber1].position);
    }
    public void SetPosition(Transform position)
    {
        SetNewPosition(position.position);
    }

}