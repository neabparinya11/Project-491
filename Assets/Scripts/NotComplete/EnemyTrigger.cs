using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnemyEnter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            OnEnemyEnter?.Invoke();
        }
    }

}
