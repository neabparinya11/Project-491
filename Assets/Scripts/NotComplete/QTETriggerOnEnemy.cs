using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETriggerOnEnemy : MonoBehaviour
{
    [SerializeField] private QTEController qteController;
    private bool enemyInRange = false;
    private bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyInRange && first)
        {
            qteController.GeneratePattern();
            first = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = false;
        }
    }
}
