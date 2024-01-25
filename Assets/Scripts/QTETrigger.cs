using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTETrigger : MonoBehaviour
{
    [SerializeField] private QTEController quickTimeEventManager;
    [SerializeField] private PlayerMovmentsScript playerMovmentsScript;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject interaction;
    [SerializeField] private Vector3 adjustPosition;
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy" )
    //    {
    //        QTEController.instance.GeneratePattern();
    //    }
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Player");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {

    //    }
    //}
}
