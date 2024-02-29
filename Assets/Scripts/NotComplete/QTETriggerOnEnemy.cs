using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTETriggerOnEnemy : MonoBehaviour
{
    [SerializeField] private QTEController qteController;
    [SerializeField] private GameObject enemyObject;
    [SerializeField] private UnityEvent OnQuickTimeEventFailed;
    [SerializeField] private UnityEvent OnQuickTimeEventSuccess;
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
            qteController.ReceiveCallbackFuntion2(OnQuickTimeEventFailed);
            qteController.ReceiveCallbackFuntion(OnQuickTimeEventSuccess);
            qteController.GeneratePattern();
            first = false;
        }
        Vector3 direction = (enemyObject.transform.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Enemy");
            }
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
