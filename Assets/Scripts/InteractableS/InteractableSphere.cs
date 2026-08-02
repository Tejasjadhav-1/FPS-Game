using UnityEngine;

public class InteractableSphere : MonoBehaviour, IInteractable
{
    public string GetInteractionText()
    {
        return "Press E to interact with the sphere.";
    }
    public void Interact()
    {
        Debug.Log("Interacted with the sphere!");
    }

}
