using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorAction : MonoBehaviour
{
    [SerializeField] Transform messagesTransform;
    [SerializeField] CanvasGroup messagePrefab;
    [SerializeField] Image messagesSprite;
    [SerializeField] Sprite normalSprite;
    //[SerializeField] Sprite failureSprite;
    //[SerializeField] TextMeshProUGUI texts;
    //[SerializeField] GameObject newPosition;
    //[SerializeField] PlayerMovmentsScript playerMovmentsScript;
    [Header("Initial Data")]
    [SerializeField] Transform newPosition;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    //[SerializeField] EnemyAi _enemyScript;
    [SerializeField] string finalScene;

    bool canAction = false; // for player check to teleport
    bool canTeleport = false; // for enemy check to teleport
    [SerializeField] bool useScene = false;
    [SerializeField] bool isLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.alpha = 1;
            messagesSprite.sprite = normalSprite;
            canAction = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.alpha = 0;
            canAction = false;
        }
        if (other.gameObject.tag == "Enemy")
        {
            canTeleport = false;
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
                if (isLocked)
                {
                        //messagesSprite.sprite = failureSprite;
                }
                else
                {
                    if (!useScene)
                    {
                        _player.transform.position = newPosition.transform.position;
                    }
                    else
                    {
                        SceneManager.LoadScene(finalScene);
                    }
                    
                }
                
                //if (_enemyScript.chasing)
                //{
                //    _enemy.transform.position = newPosition.transform.position;
                //}
            }
        }

        if (canTeleport)
        {
            EnemyAi enemyScript = _enemy.GetComponentInChildren<EnemyAi>();
            if (enemyScript.chasing)
            {
                enemyScript.SetNewPosition(newPosition.transform.position);
                canTeleport = false;
            }
        }
    }

    public void SetDoorLocked(bool locked)
    {
        this.isLocked = locked;
    }

    public bool GetDoorLocked()
    {
        return this.isLocked;
    }
}
