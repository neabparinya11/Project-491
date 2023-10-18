using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public static StoryController instance;
    [SerializeField] GameObject enemy;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] AudioSource bgSoundSpawnEnemy;
    [SerializeField] AudioSource bgSound;
    [SerializeField] AudioSource bgSoundHideAndSeek;
    [SerializeField] GameObject finalDoor;
    protected bool spawnEnemy = false;
    protected bool enemyChasing = false;
    protected bool doorLocked = false;
    public bool getDoorKey = false;
    protected bool atFirst;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bgSound.loop = true;
        bgSoundHideAndSeek.loop = false;
        bgSound.enabled = true;
        bgSoundSpawnEnemy.enabled = true;
        bgSoundHideAndSeek.enabled = true;
        bgSound.Play();
    }

    // Update is called once per frame
    void Update()
    {

        // Sound Control
        if (inventoryManager.ListQuestionItem.Count == 1 )
        {
            enemy.SetActive(true);
            if (atFirst)
            {

            }
            else
            {
                enemy.GetComponent<EnemyAi>().SetStart();
            }
            
            atFirst = true;
            spawnEnemy = true;
        }
        else
        {
            enemy.SetActive(false);
            bgSoundSpawnEnemy.Stop();
        }

        

        //if (spawnEnemy)
        //{
        //    if (!bgSoundSpawnEnemy.isPlaying)
        //    {
        //        bgSound.Pause();
        //        bgSoundSpawnEnemy.Play();
        //    }
            
        //    //if (!bgSoundSpawnEnemy.isPlaying)
        //    //{
        //    //    spawnEnemy = false;
        //    //    bgSound.Play();
        //    //}
        //}

        if (enemyChasing)
        {
            if (bgSound.isPlaying)
            {
                bgSound.Pause();
            }
            if (!bgSoundHideAndSeek.isPlaying)
            {
                bgSoundHideAndSeek.Play();
            }
        }
        else
        {
            if (bgSoundHideAndSeek.isPlaying)
            {
                bgSoundHideAndSeek.Stop();
            }
            if (!bgSound.isPlaying)
            {
                bgSound.Play();
            }
        }

        if (getDoorKey)
        {
            finalDoor.GetComponent<DoorAction>().SetDoorLocked(false);
        }

        Debug.Log("Background Sound Spawn : " + bgSoundSpawnEnemy.isPlaying);
        Debug.Log("Background Sound : " + bgSound.isPlaying);
        Debug.Log("Background Hide and Seek : " + bgSoundHideAndSeek.isPlaying);
    }

    public void SetChasingBoolean(bool chase)
    {
        enemyChasing = chase;
    }
}
