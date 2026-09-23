using UnityEngine;

public class BatteryPickup : MonoBehaviour, IInteractable
{
    [SerializeField] string itemName = "Battery";

    public string GetInteractionText()
    {
        return $"Press E to pickup{itemName}";
    }

    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
