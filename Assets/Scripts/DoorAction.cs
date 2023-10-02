using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorAction : MonoBehaviour
{
    [SerializeField] Transform messagesTransform;
    [SerializeField] Canvas messagePrefab;
    //[SerializeField] TextMeshProUGUI texts;
    //[SerializeField] GameObject newPosition;
    //[SerializeField] PlayerMovmentsScript playerMovmentsScript;
    [Header("Initial Data")]
    [SerializeField] Transform newPosition;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] EnemyAi _enemyScript;

    bool canAction = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.enabled = true;
            canAction = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.enabled = false;
            canAction = false;
        }
    }

    private void Update()
    {
        Vector3 objectPosition = transform.position + new Vector3(0.8f, 1, 0);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        messagesTransform.position = screenPosition;
        if (canAction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _player.transform.position = newPosition.transform.position;
                if (_enemyScript.chasing)
                {
                    _enemy.transform.position = newPosition.transform.position;
                }
            }
        }
    }
}
