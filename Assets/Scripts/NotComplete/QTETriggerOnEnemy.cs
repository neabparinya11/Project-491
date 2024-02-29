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
    [SerializeField] private bool first = true;
    private HidingObject hidingScript;

    // Start is called before the first frame update
    void Start()
    {
        this.hidingScript = GetComponent<HidingObject>();
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
            if (hit.collider.gameObject.tag == "Enemy" && hidingScript.GetHidingState() && first)
            {
                Debug.Log("Enemy");
                first = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
            first = true;
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
