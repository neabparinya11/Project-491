using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerTrigger;
 
    public delegate void MessageHandle(string messages);
    public event MessageHandle OnMessageRecieve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerTrigger?.Invoke();
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void Start()
    {
        OnMessageRecieve += HandleMessageRecieve1;
        OnMessageRecieve += HandleMessageRecieve2;

        //SendMessaageToSubscribes("Send To Sub");
    }

    public void SendMessaageToSubscribes(string message)
    {
        OnMessageRecieve?.Invoke(message);
    }

    public void HandleMessageRecieve1(string messages)
    {
        Debug.Log("Message 1 Recieve: " + messages);
    }

    public void HandleMessageRecieve2(string messages)
    {
        Debug.Log("Message 2 Recieve: " + messages);
    }
}
