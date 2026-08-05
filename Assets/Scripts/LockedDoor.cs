using UnityEngine;

public class LockedDoor : MonoBehaviour, IInteractable
{
    [SerializeField] string requiredItem = "Key";

    bool isUnlocked = false;

    DoorInteractable door;

    private void Start()
    {
        door = GetComponent<DoorInteractable>();
    }

    public string GetInteractionText()
    {
        if (!isUnlocked)
        {
            return $"Press E to open ({requiredItem})";
        }
        else
        {
           return door.GetInteractionText();
        }
    }
    public void Interact(GameObject player)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        if (isUnlocked)
        {
            if (!door.IsOpen)
            {
                door.OpenDoor();
            }
            else
            {
                door.CloseDoor();
            }
        }
        else
        {
            if (inventory.HasItem(requiredItem))
            {
                isUnlocked = true;
                door.OpenDoor();
            }
            else
            {
                Debug.Log($"Need: {requiredItem}");
            }
        }
    }
}
