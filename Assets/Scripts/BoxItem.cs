using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxItem : MonoBehaviour
{
    [SerializeField] private string id;
    //public List<GameObject> listItem = new List<GameObject>();
    [SerializeField] private List<FoodItem> listItemObject = new List<FoodItem>();
    public QuestionItem questionItem;
    [SerializeField] GameObject loadStock;
    //public GameObject interaction;
    public Transform loadStockTransform;
    public Slider slide;
    [SerializeField] CanvasGroup canvas;
    [SerializeField] GameObject interaction;

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
                this.enabled = false;
                return;
            }
            
            if (Input.GetKey(KeyCode.E))
            {
                //interaction.SetActive(false);
                loadStock.SetActive(true);
                currentLoad += speed * Time.deltaTime;
                slide.value = currentLoad;
            }
            if (currentLoad >= maxLoad)
            {
                loadStock.SetActive(false);
                RandomItem();
                //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            if (currentLoad < maxLoad && !Input.GetKey(KeyCode.E))
            {
                currentLoad -= speed * Time.deltaTime;
                slide.value = currentLoad;
                if (currentLoad <= 0)
                {
                    currentLoad = 0;
                    slide.value = 0;
                    loadStock.SetActive(false);
                    //interaction.SetActive(true);
                }
            }
            if (currentLoad == 0)
            {
                canvas.alpha = 1;
            }
        }
    }
    private void RandomItem()
    {
        var index = UnityEngine.Random.Range(0, listItemObject.Count);
        if (questionItem != null)
        {
            InventoryManager.Instance.AddQuestionItem(questionItem);
        }
        else
        {
            InventoryManager.Instance.AddFoodItem(listItemObject[index]);
        }
        
        isSearch = true;

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hide text or disable.
            canvas.alpha = 0;
            //interaction.SetActive(true);
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
        //interaction.transform.position = screenPosition;
    }

    //public void SaveData(ref GameData gameData)
    //{
    //    if (gameData.dictBoxItem.ContainsKey(id))
    //    {
    //        gameData.dictBoxItem.Remove(id);
    //    }
    //    gameData.dictBoxItem.Add(id, isSearch);
    //}

    //public void LoadData(GameData gameData)
    //{
    //    gameData.dictBoxItem.TryGetValue(id, out isSearch);
    //}
}
