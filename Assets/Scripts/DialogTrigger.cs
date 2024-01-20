using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualButton;
    [SerializeField] private TextAsset inkJson;
    [SerializeField] private Vector3 adjustPosition = new Vector3(0.8f, 1, 0);
    [SerializeField] private DialogManager dialogueManager;
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
        if (playerInRange && !DialogManager.GetInstance().dialogIsPlaying)
        {
            visualButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                dialogueManager.EnterDialogMode(inkJson);
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
