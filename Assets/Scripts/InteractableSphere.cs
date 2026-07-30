using UnityEngine;

public class InteractableSphere : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with the sphere!");
        
    }   

}
