using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SanityTrigger : MonoBehaviour
{
    [SerializeField] private GameObject enemyAi;
    [SerializeField] private Vector3 rayCastOffset;
    [SerializeField] private UnityEvent OnEnemyInRange;

    private bool playerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        // Vector3 direction = (enemyAi.transform.position - transform.position).normalized;
        // if (Physics.Raycast(transform.position + rayCastOffset, direction, out hit))
        // {
        //     if (hit.collider.gameObject.tag == "Enemy")
        //     {
        //         OnEnemyInRange?.Invoke();
        //     }
        // }
        if (playerInRange)
        {
            OnEnemyInRange?.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            this.enabled = false;
        }
    }
}
