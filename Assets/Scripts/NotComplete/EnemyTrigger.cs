using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnEnemyEnterBadEnd;
    [SerializeField] private UnityEvent OnEnemyEnterGoodEnd;
    [SerializeField] private DialogManager dialogManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (dialogManager.CheckKeyItem("bad_end"))
            {
                OnEnemyEnterBadEnd?.Invoke();
            }
            else
            {
                OnEnemyEnterGoodEnd?.Invoke();
            }
        }
    }

}
