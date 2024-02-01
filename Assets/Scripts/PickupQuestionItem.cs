using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PickupQuestionItem : MonoBehaviour
{
    [SerializeField] QuestionItem questionItem;
    [SerializeField] CanvasGroup canva;
    [SerializeField] GameObject interaction;
    [SerializeField] Image icon;
    [SerializeField] Sprite interactionIcon;
    [SerializeField] UnityEvent<string, Sprite> OnPlayerPickup;

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
        if (_canInteraction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InventoryManager.Instance.AddQuestionItem(questionItem);
                OnPlayerPickup?.Invoke(questionItem.itemName, questionItem.icon);
                Destroy(gameObject);
            }
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canva.alpha = 1;
            _canInteraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canva.alpha = 0;
            _canInteraction = false;
        }
    }
}
