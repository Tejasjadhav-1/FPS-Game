using UnityEngine;

public class InteractableSphere : MonoBehaviour, IInteractable
{
    public string GetInteractionText()
    {
        return "Press E to interact with the sphere.";
    }
    public void Interact(GameObject player)
    {
        Debug.Log("Interacted with the sphere!");
        
    }

}
