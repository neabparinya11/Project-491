using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyObject.SetActive(true);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
