using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float interactionDistance = 3f;
    [SerializeField] LayerMask interactableLayer;

    [SerializeField] TMP_Text interactionText;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {

            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                interactionText.gameObject.SetActive(true);

                interactionText.text = interactable.GetInteractionText();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact(gameObject);
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