using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour
{
    [SerializeField] GameObject hideText;
    [SerializeField] GameObject normalPlayer, hidingPlayer;
    [SerializeField] EnemyAi enemyAi;
    [SerializeField] Transform monster;
    [SerializeField] float loseDistance;
    bool interactAble, hiding;

    // Start is called before the first frame update
    void Start()
    {
        interactAble = false;
        hiding = false;
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

                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(""))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(""))
        {

        }
    }
}
