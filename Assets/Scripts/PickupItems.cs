using UnityEngine;

public class PickupItems : MonoBehaviour, IInteractable 
{
    [SerializeField] int healAmount = 25;
    public string GetInteractionText()
    {
        return "Press E to pickup Heal";
    }
    public void Interact(GameObject player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null )
        {
            playerHealth.Heal(healAmount);
            //Destroy(gameObject);
        }
    }
}
