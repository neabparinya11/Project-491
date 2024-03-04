using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerEnter?.Invoke();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
