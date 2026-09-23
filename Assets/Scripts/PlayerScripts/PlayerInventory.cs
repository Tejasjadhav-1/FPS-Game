using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class PlayerInventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryPannel;
    [SerializeField] TMP_Text inventoryItemsList;
    Dictionary<string, int> items = new Dictionary<string, int>();

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
        if (!items.ContainsKey(itemName))
        {
            items.Add(itemName, 1);
            UpdateInventoryUI();
            Debug.Log($"{itemName} added to inventory");
        }
        else
        {
            items[itemName]++;
            UpdateInventoryUI();
            Debug.Log($"{itemName} is already in inventory");
        }
    }

    public bool HasItem(string itemName)
    {
        return items.ContainsKey(itemName); 
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
            foreach (KeyValuePair<string, int> item in items)
            {
                inventoryText += item.Key + " x" + item.Value + "\n";
            }

            inventoryItemsList.text = inventoryText;
        }
    }
    
    
}

