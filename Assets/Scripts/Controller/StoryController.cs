using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    public static StoryController instance;
    [SerializeField] GameObject enemy;
    [SerializeField] InventoryManager inventoryManager;

    protected int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryManager.ListQuestionItem.Count == 1)
        {
            enemy.SetActive(true);
        }
        else
        {
            enemy.SetActive(false);
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
