using UnityEngine;

public class KeyPickup : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName = "Key";
    public string GetInteractionText()
    {
        return "Press E to pickup key";
    }
    public void Interact(GameObject player)
    {
        Debug.Log("Interacted with key");
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemName);
            Destroy(gameObject);
        }

    }
    
}
