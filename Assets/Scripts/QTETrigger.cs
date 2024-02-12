using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTETrigger : MonoBehaviour
{
    [SerializeField] private QTEController quickTimeEventManager;
    [SerializeField] private PlayerMovmentsScript playerMovmentsScript;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject interaction;
    [SerializeField] private Vector3 adjustPosition;
    [SerializeField] private UnityEvent OnPlayerSuccessQTE;
    [SerializeField] private UnityEvent OnPlayerFailedQTE;
    private static QTETrigger instance;
    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public static QTETrigger GetInstance()
    {
        return instance;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition = transform.position + adjustPosition;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        interaction.GetComponent<Transform>().position = screenPosition;
        if (playerInRange && quickTimeEventManager != null)
        {
            quickTimeEventManager.ReceiveCallbackFuntion(OnPlayerSuccessQTE);
            quickTimeEventManager.ReceiveCallbackFuntion2(OnPlayerFailedQTE);
            if (Input.GetKeyDown(KeyCode.E))
            {
                canvasGroup.alpha = 0;
                quickTimeEventManager.GeneratePattern();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
            canvasGroup.alpha = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
            canvasGroup.alpha = 0;
        }
    }
}
