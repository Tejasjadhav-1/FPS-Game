using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactionDistance = 3f;
    [SerializeField] LayerMask interactableLayer;

    [SerializeField] TMP_Text interactionText;

    void Update()
    {
        // Create a ray from the camera's position in the direction it's facing
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

        RaycastHit hit;

        // Check if the ray hits an object on the interactable layer
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            // Get the interactable component from the hit object
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // Only continue if the object implements IInteractable
            if (interactable != null)
            {
                interactionText.gameObject.SetActive(true);

                // Display the interaction prompt provided by the object
                interactionText.text = interactable.GetInteractionText();

                // Interact when the player presses E
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }
    }
}