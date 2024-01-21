using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> listObject;
    [SerializeField] private List<DoorAction> listDoorAction;
    [SerializeField] private AudioSource soundBell;
    private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach (DoorAction door in listDoorAction)
        {
            door.SetDoorLocked(true);
        }

        foreach (GameObject obj in listObject)
        {
            obj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFirst)
        {
            foreach (GameObject obj in listObject)
            {
                obj.SetActive(false);
            }
            isFirst = true;
        }
    }
}
