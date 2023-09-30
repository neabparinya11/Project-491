using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StableTeleport : MonoBehaviour
{
    [SerializeField] Transform choice1, choice2;
    [SerializeField] GameObject _player;
    [SerializeField] Transform messageTransform;
    [SerializeField] CanvasGroup canvasGroup;
    bool _canTeleport = false;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

        }
    }
}
