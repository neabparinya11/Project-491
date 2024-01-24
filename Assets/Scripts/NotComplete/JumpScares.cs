using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScares : MonoBehaviour
{
    [SerializeField] private GameObject jumpscareObject;
    [SerializeField] private AudioSource jumpscareSound;
    [SerializeField] private float jumpscareTime;
    private bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && trigger)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            jumpscareObject.SetActive(true);

            StartCoroutine(PlayJumpScare());
            if (!jumpscareSound.isPlaying)
            {
                jumpscareSound.Play();
            }
            
        }
    }

    IEnumerator PlayJumpScare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        jumpscareObject.SetActive(false);
    }
}
