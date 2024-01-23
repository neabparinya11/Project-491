using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualButton;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private Vector3 adjustPosition;
    [SerializeField] private DialogManager dialogManager;
    [SerializeField] private AudioSource backgroundSound;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        visualButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition = transform.position + adjustPosition;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        visualButton.transform.position = screenPosition;
        if (playerInRange && !dialogManager.dialogIsPlaying)
        {
            visualButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogManager.EnterDialogueWithTime( 4.0f, inkJson);
                EmergencyControl.GetInstance().DiableAllCharacter();
                EmergencyControl.GetInstance().UnlockedAllDoor();
                EmergencyControl.GetInstance().PlaySoundBell();
                backgroundSound.Pause();
            }
        }
        else
        {
            visualButton.SetActive(false);
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
}
