using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour
{
    [SerializeField] Transform hideText;
    //[SerializeField] Transform enemy;
    [SerializeField] float distance;
    [SerializeField] GameObject normalPlayer;
    [SerializeField] EnemyAi enemyAiScript;
    [SerializeField] Transform monster;
    [SerializeField] float loseDistance;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] Vector3 adjustPosition;
    bool interactAble, hiding;

    // Start is called before the first frame update
    void Start()
    {
        interactAble = false;
        hiding = false;
        canvas.alpha = .0f;
        //stopHideText.SetActive(false);
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
                else
                {
                    ExitHiding();
                }
                canvas.alpha = 0.0f;
                hiding = true;
                normalPlayer.SetActive(false);
                interactAble = false;
            }
        }
        if (hiding)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ExitHiding();
            }
            //QTEController.instance.isQTEenable = true;
        }
        //Vector3 direction = (enemy.position - transform.position).normalized;
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, direction, out hit, distance))
        //{
        //    Debug.Log(hit.collider.gameObject.tag == "Eenemy");
        //    if (hit.collider.gameObject.tag == "Eenemy")
        //    {
        //        QTEController.instance.isQTEenable = true;
        //    }
        //}
        Vector3 objectPosition = transform.position + adjustPosition;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        hideText.position = screenPosition;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.alpha = 1.0f;
            interactAble = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.alpha = 0.0f;
            interactAble = false;
        }
    }

    public void ExitHiding()
    {
        canvas.alpha = 0.0f;
        normalPlayer.SetActive(true);
        hiding = false;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        QTEController.instance.isQTEenable = true;
    //    }
    //}
    public bool GetHidingState()
    {
        return hiding;
    }
}
