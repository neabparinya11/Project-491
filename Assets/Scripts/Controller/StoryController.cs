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
    protected bool spawnEnemy = false;
    protected bool enemyChasing = false;
    protected int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        bgSound.loop = true;
        bgSoundHideAndSeek.loop = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (inventoryManager.ListQuestionItem.Count == 1)
        {
            enemy.SetActive(true);
            spawnEnemy = true;
        }
        else
        {
            enemy.SetActive(false);
        }

        bgSound.Play();

        if (spawnEnemy)
        {
            bgSoundSpawnEnemy.Play();
            if (!bgSoundSpawnEnemy.isPlaying)
            {
                spawnEnemy = false;
                bgSound.Play();
            }
        }

        if (enemyChasing)
        {
            if (bgSound.isPlaying)
            {
                bgSound.Pause();
            }
            bgSoundHideAndSeek.Play();
        }
        else
        {
            bgSoundHideAndSeek.Stop();
        }
        
        
    }

    public void InCreaseState()
    {
        state += 1;
    }

    public void DecreaseState()
    {
        state -= 1;
    }
}
