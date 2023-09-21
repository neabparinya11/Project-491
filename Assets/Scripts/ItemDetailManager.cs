using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDetailManager : MonoBehaviour
{
    public static ItemDetailManager Instance;
    public GameObject detailPanel;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemRestoreHealth;
    [SerializeField] TextMeshProUGUI itemRestoreStamina;
    [SerializeField] TextMeshProUGUI itemRestoreSanity;

    public float health, stamina, sanity;
    public string name, description;

    private void Start()
    {
        Instance = this;
        itemName.text = "";
        itemDescription.text = "";
    }
    private void Update()
    {
        itemName.text = name;
        itemDescription.text = description;
    }

    public void SetActivePanel(bool _open)
    {
        detailPanel.SetActive(_open);
    }
}
