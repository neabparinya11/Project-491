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
    public Button useItemBtn;
    public Button dropItemBtn;

    public float health, stamina, sanity;
    public string nameitem, description;

    private void Start()
    {
        Instance = this;
        itemName.text = "";
        itemDescription.text = "";
        itemRestoreHealth.text = "";
        itemRestoreStamina.text = "";
        itemRestoreSanity.text = "";
    }

    public void ClearDetail()
    {
        itemName.text = "";
        itemDescription.text = "";
        itemRestoreHealth.text = "";
        itemRestoreStamina.text = "";
        itemRestoreSanity.text = "";
        Instance.useItemBtn.onClick.RemoveAllListeners();
        Instance.dropItemBtn.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        itemName.text = nameitem;
        itemDescription.text = description;
        if (health != 0)
        {
            itemRestoreHealth.text = "Heal + " + health;
            itemRestoreHealth.color = Color.red;
        }
        if (stamina != 0)
        {
            itemRestoreStamina.text = "Stamina + " + stamina;
            itemRestoreStamina.color = Color.blue;
        }
        if (sanity != 0)
        {
            itemRestoreStamina.text = "Sanity + " + sanity;
            itemRestoreSanity.color = Color.green;
        }
    }

    public void SetActivePanel(bool _open)
    {
        detailPanel.SetActive(_open);
    }
}
