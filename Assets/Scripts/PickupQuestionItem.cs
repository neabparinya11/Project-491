using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupQuestionItem : MonoBehaviour
{
    [SerializeField] QuestionItem questionItem;
    [SerializeField] GameObject interaction;
    [SerializeField] Image icon;
    [SerializeField] Sprite interactionIcon;

    protected bool _canInteraction = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition = transform.position;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        interaction.transform.position = screenPosition;
        icon.sprite = interactionIcon;
        if (Input.GetKeyDown(KeyCode.E))
        {
            InventoryManager.Instance.AddQuestionItem(questionItem);
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction.SetActive(true);
            _canInteraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction.SetActive(false);
            _canInteraction = false;
        }
    }
}
