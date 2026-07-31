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
            interactionText.gameObject.SetActive(true);           
            //Debug.Log("Hit");

            if (Input.GetKeyDown(KeyCode.E))
            {                
                //Debug.Log("E Pressed");

                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                //Debug.Log(interactable);

                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
        }



    }
}
