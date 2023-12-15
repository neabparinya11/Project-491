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
    [Header("Initial Data")]
    [SerializeField] Transform newPosition;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] string finalScene;

    bool canAction = false; // for player check to teleport
    bool canTeleport = false; // for enemy check to teleport
    [SerializeField] bool useScene = false;
    [SerializeField] bool isLocked = true;

    private void Start()
    {
        StartCoroutine(TeleportEnemy());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.alpha = 1;
            messagesSprite.sprite = normalSprite;
            canAction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messagePrefab.alpha = 0;
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
                canTeleport = true;
            }
        }
        if (canTeleport)
        {
            StartCoroutine(TeleportEnemy());
            canTeleport = false;
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

    IEnumerator TeleportEnemy()
    {
        yield return new WaitForSeconds(2);
        EnemyAi _enemyScript = _enemy.GetComponentInChildren<EnemyAi>();
        _enemyScript.SetNewPosition(newPosition.transform.position);
        //canTeleport = false;
    }
}
