using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemyObject;
    private EnemyAi enemyScript;
    private int countUp = 1;

    private void Start()
    {
        enemyScript = enemyObject.GetComponentInChildren<EnemyAi>();
    }

    private void Update()
    {
        countUp++;
        if (!enemyScript.chasing && countUp % 1000 == 0)
        {
            RandomSpawn();
        }
    }

    public void RandomSpawn()
    {
        StartCoroutine(enemyScript.RandomSpawn());
    }
}
