using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPannel;
    [SerializeField] TMP_Text inventoryItemsList;
    List<string> items = new List<string>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        UpdateInventoryUI();
        inventoryPannel.SetActive(!inventoryPannel.activeSelf);
    }

    public void AddItem(string itemName)
    {
        if (!items.Contains(itemName))
        {
            items.Add(itemName);
            UpdateInventoryUI();
            Debug.Log($"{itemName} added to inventory");
        }
        else
        {
            Debug.Log($"{itemName} is already in inventory");
        }
    }

    public bool HasItem(string itemName)
    {
        return items.Contains(itemName); 
    }

    private void UpdateInventoryUI()
    {
        if (items.Count == 0)
        {
            inventoryItemsList.text = "Inventory is empty.";
        }
        else
        {
            string inventoryText = "";
            foreach (string item in items)
            {
                inventoryText += "*" + item + "\n";
            }

            inventoryItemsList.text = inventoryText;
        }
    }
    
    
}

