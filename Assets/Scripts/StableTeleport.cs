using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StableTeleport : MonoBehaviour
{
    [SerializeField] Transform choice1, choice2;
    [SerializeField] GameObject _player;
    [SerializeField] Transform messageTransform1, messageTransform2;
    [SerializeField] Image _messageImage1, _messageImage2;
    [SerializeField] Sprite _messageSprite1, _messageSprite2;
    [SerializeField] CanvasGroup canvasGroup;
    bool _canTeleport = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 objectPosition1 = transform.position + new Vector3(0, 0.5f, 0);
        Vector3 objectPosition2 = transform.position;
        Vector3 screenPosition1 = Camera.main.WorldToScreenPoint(objectPosition1);
        Vector3 screenPosition2 = Camera.main.WorldToScreenPoint(objectPosition2);
        if (!_canTeleport)
        {
            return;
        }
        if (_messageImage1 != null && choice1 != null)
        {
            messageTransform1.position = screenPosition1;
            _messageImage1.sprite = _messageSprite1;
            if (Input.GetKeyDown(KeyCode.W))
            {
                _player.transform.position = choice1.position;
            }
        }

        if (_messageImage2 != null && choice2 != null)
        {
            messageTransform2.position = screenPosition2;
            _messageImage2.sprite = _messageSprite2;
            if (Input.GetKeyDown(KeyCode.S))
            {
                _player.transform.position = choice2.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasGroup.alpha = 1;
            _canTeleport = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _canTeleport = false;
            canvasGroup.alpha = 0;
        }
    }
}
