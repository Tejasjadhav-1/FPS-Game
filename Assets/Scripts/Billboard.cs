using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    private void Update()
    {
        transform.rotation = playerCamera.transform.rotation;
    }
}
