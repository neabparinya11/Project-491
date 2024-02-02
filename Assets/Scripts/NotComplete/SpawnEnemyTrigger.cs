using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;

    [SerializeField] private delegate void SomethingSmoothy(int num);
    private SomethingSmoothy something;

    public SpawnEnemyTrigger()
    {
        this.something = Functional;
        this.something?.Invoke(1232);
    }

    private void Functional(int num)
    {
        Console.WriteLine("Something smoothy: " + num);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyObject.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
