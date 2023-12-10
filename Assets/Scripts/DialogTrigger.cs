using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualButton;

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
        if (playerInRange)
        {
            visualButton.SetActive(true);
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
