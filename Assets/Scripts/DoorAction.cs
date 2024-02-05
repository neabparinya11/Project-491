using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class DoorAction : MonoBehaviour
{
    [SerializeField] private string id;
    //[SerializeField] Transform messagesTransform;
    [SerializeField] CanvasGroup messageCanvasGroup;
    [SerializeField] Image messagesSprite;
    [SerializeField] Sprite normalSprite;
    [SerializeField] Sprite failureSprite;
    [Header("Initial Data")]
    [SerializeField] Transform newPosition;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] string finalScene;
    [SerializeField] private bool useEnemy;
    [SerializeField] private Vector3 adjustPosition = new Vector3(0.8f, 1, 0);
    bool canAction = false; // for player check to teleport
    bool canTeleport = false; // for enemy check to teleport
    [SerializeField] bool useScene = false;
    [SerializeField] bool isLocked = true;
    [SerializeField] string findItem;
    [SerializeField] bool useKey = false;
    [SerializeField] PasswordPuzzle passwordPuzzle;
    private static DoorAction instance;
    [SerializeField] UnityEvent<string> OnPlayerActionToNextScene;
    [SerializeField] public UnityEvent<GameObject, Vector3> OnPlayerActionToNextPosition;
    [SerializeField] private UnityEvent OnWillUnlockDoor;
    [SerializeField] private UnityEvent OnAfterUnlockDoor;

    private void Start()
    {
        instance = this;

        messagesSprite.sprite = !isLocked ? normalSprite : failureSprite;
    }

    public static DoorAction GetInstance()
    {
        return instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messageCanvasGroup.alpha = 1;
            //messagesSprite.sprite = normalSprite;
            canAction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            messageCanvasGroup.alpha = 0;
            canAction = false;
        }
    }

    private void Update()
    {
        Vector3 objectPosition = transform.position + adjustPosition;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        messagesSprite.GetComponent<Transform>().position = screenPosition;

        if (isLocked && canAction)
        {
            //isLocked = false;
            if ( findItem != string.Empty && InventoryManager.Instance.FindQuestItem(findItem) && useKey)
            {
                isLocked = false;
            }
            messagesSprite.sprite = failureSprite;

            //if (Input.GetKeyDown(KeyCode.E) && passwordPuzzle != null)
            //{
            //    messageCanvasGroup.alpha = 0;
            //    passwordPuzzle.GeneratePasscode();
            //}
            if (Input.GetKeyDown(KeyCode.E))
            {
                passwordPuzzle.ReceiveCallbackFunction(OnAfterUnlockDoor);
                OnWillUnlockDoor?.Invoke();
            }
        }
        else
        {
            messagesSprite.sprite = normalSprite;
        }
        if (canAction && Input.GetKeyDown(KeyCode.E) && !isLocked)
        {
            OnPlayerActionToNextScene?.Invoke(finalScene);
            OnPlayerActionToNextPosition?.Invoke(_player, newPosition.transform.position);
            canTeleport = true;
        }
        if (canTeleport && useEnemy)
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

    //public void SaveData(ref GameData gameData)
    //{
    //    if (gameData.dictDoorAction.ContainsKey(id))
    //    {
    //        gameData.dictDoorAction.Remove(id);
    //    }

    //    gameData.dictDoorAction.Add(id, isLocked);
    //}

    //public void LoadData(GameData gameData)
    //{
    //    gameData.dictDoorAction.TryGetValue(id, out isLocked);
    //}
}
