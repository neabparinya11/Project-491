using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : MonoBehaviour
{
    //public List<GameObject> listItem = new List<GameObject>();
    public List<FoodItem> listItemObject = new List<FoodItem>();
    public GameObject loadStock;
    public Slider slide;
    public Text textCommand;
    float speed = 20.0f;
    float maxLoad = 100.0f;
    float currentLoad = 0.0f;
    bool isSearch = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (isSearch)
            {
                return;
            }
            
            if (Input.GetKey(KeyCode.E))
            {
                loadStock.SetActive(true);
                currentLoad += speed * Time.deltaTime;
                slide.value = currentLoad;
            }
            if (currentLoad >= maxLoad)
            {
                loadStock.SetActive(false);
                RandomItem();
            }
        }
    }
    private void RandomItem()
    {
        var index = UnityEngine.Random.Range(0, listItemObject.Count);
        Debug.Log(listItemObject[index].name);
        InventoryManager.Instance.AddFoodItem(listItemObject[index]);
        isSearch = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide text or disable.
            loadStock.SetActive(false);
        }
    }
}
