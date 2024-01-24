using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    [SerializeField] private QTEController quickTimeEventManager;
    private static QTETrigger instance;
    private bool playerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && quickTimeEventManager != null)
        {

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
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" )
    //    {
    //        QTEController.instance.GeneratePattern();
    //    }
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Player");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {

    //    }
    //}
}
