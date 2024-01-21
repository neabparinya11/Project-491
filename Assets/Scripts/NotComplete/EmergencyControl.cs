using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyControl : MonoBehaviour
{
    [SerializeField] private List<GameObject> listObject;
    [SerializeField] private List<DoorAction> listDoorAction;
    [SerializeField] private AudioSource soundBell;
    private static EmergencyControl instance;
    //private bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        foreach (DoorAction door in listDoorAction)
        {
            door.SetDoorLocked(true);
        }

        foreach (GameObject obj in listObject)
        {
            obj.SetActive(true);
        }
    }

    public static EmergencyControl GetInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isFirst)
        //{
        //    foreach (GameObject obj in listObject)
        //    {
        //        obj.SetActive(false);
        //    }
        //    isFirst = true;
        //}
    }

    public void DiableAllCharacter()
    {
        foreach (GameObject obj in listObject)
        {
            obj.SetActive(false);
        }
    }

    public void UnlockedAllDoor()
    {
        foreach (DoorAction door in listDoorAction)
        {
            door.SetDoorLocked(false);
        }
    }

    public void PlaySoundBell()
    {
        soundBell.Play();
    }
}
