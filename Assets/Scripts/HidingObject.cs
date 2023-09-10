using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour
{
    [SerializeField] GameObject hideText, stopHideText;
    [SerializeField] GameObject normalPlayer, hidingPlayer;
    [SerializeField] EnemyAi enemyAiScript;
    [SerializeField] Transform monster;
    [SerializeField] float loseDistance;
    bool interactAble, hiding;

    // Start is called before the first frame update
    void Start()
    {
        interactAble = false;
        hiding = false;
        hideText.SetActive(false);
        stopHideText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactAble)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                float distance = Vector3.Distance(monster.transform.position, normalPlayer.transform.position);
                if (distance > loseDistance)
                {
                    if (enemyAiScript.chasing == true)
                    {
                        enemyAiScript.stopChase();

                    }
                }
                hideText.SetActive(false);
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactAble = false;
            }
        }
        if (hiding)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
                hiding = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hideText.SetActive(true);
            interactAble = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hideText.SetActive(false);
            interactAble = false;
        }
    }
}
