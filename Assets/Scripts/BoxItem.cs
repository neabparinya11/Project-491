using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : MonoBehaviour
{
    //public List<GameObject> listItem = new List<GameObject>();
    public List<FoodItem> listItemObject = new List<FoodItem>();
    public GameObject loadStock;
    public GameObject interaction;
    public Transform loadStockTransform;
    public Slider slide;
    [SerializeField] CanvasGroup canvas;
    
    float speed = 20.0f;
    float maxLoad = 100.0f;
    float currentLoad = 0.0f;
    bool isSearch = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            //interaction.SetActive(true);
            if (isSearch)
            {
                return;
            }
            
            if (Input.GetKey(KeyCode.E))
            {
                interaction.SetActive(false);
                loadStock.SetActive(true);
                currentLoad += speed * Time.deltaTime;
                slide.value = currentLoad;
            }
            if (currentLoad >= maxLoad)
            {
                loadStock.SetActive(false);
                RandomItem();
            }
            if (currentLoad < maxLoad && !Input.GetKey(KeyCode.E))
            {
                currentLoad -= speed * Time.deltaTime;
                slide.value = currentLoad;
                if (currentLoad <= 0)
                {
                    currentLoad = 0;
                    slide.value = 0;
                }
            }
            if (currentLoad == 0)
            {
                Debug.Log("current");
                canvas.alpha = 1;
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
            canvas.alpha = 0;
            interaction.SetActive(false);
            loadStock.SetActive(false);
            currentLoad = 0.0f;
        }
    }

    private void Update()
    {
        Vector3 objectPosition = transform.position + new Vector3(0.5f, 0.5f, 0);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);
        loadStockTransform.position = screenPosition;
        interaction.transform.position = screenPosition;
    }
}
