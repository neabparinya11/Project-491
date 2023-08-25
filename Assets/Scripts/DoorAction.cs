using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorAction : MonoBehaviour
{
    //[SerializeField] GameObject messages;
    //[SerializeField] TextMeshProUGUI texts;
    //[SerializeField] GameObject newPosition;
    //[SerializeField] PlayerMovmentsScript playerMovmentsScript;
    [Header("Initial Data")]
    [SerializeField] Transform newPosition;
    [SerializeField] GameObject _player;

    bool canAction = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //messages.SetActive(true);
            canAction = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //messages.SetActive(false);
            canAction = false;
        }
    }

    private void Update()
    {
        if (canAction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _player.transform.position = newPosition.transform.position;
            }
        }
    }
}
