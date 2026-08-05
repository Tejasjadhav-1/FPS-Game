using UnityEngine;


public class DoorInteractable : MonoBehaviour, IInteractable
{
    
    bool isOpen = false;

    public bool IsOpen => isOpen;

    Quaternion openRotation;
    Quaternion closeRotation;

    [SerializeField] float rotationSpeed = 90f;
    [SerializeField] float openAngle = -90f;


    private void Start()
    {
        closeRotation = transform.rotation;
        openRotation = closeRotation * Quaternion.Euler(0f, openAngle, 0f);
        
    }

    private void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, rotationSpeed*Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, closeRotation, rotationSpeed *Time.deltaTime);
        }
    }


    public string GetInteractionText()
    {
        if (isOpen)
        {
            return "Press E to close the door";
        }
        return "Press E to open the door";
    }
    public void Interact(GameObject player)
    {
        isOpen = !isOpen;
    }

    public void OpenDoor()
    {
        isOpen = true;
    }
    public void CloseDoor()
    {
        isOpen = false;
    }

}
