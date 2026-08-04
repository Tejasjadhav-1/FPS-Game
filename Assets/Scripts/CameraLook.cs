using UnityEngine;


public class CameraLook : MonoBehaviour
{
    [SerializeField] float mouseYawSensitivity = 100f;
    [SerializeField] float mousePitchSensitivity = 100f;
    [SerializeField] Transform cameraHolder;
    

    float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        LockCursor();
    }

    void Update()
    {

        float mouseX = Input.GetAxisRaw("Mouse X"); 
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float mouseYaw = mouseX * mouseYawSensitivity * Time.deltaTime;

        pitch += mouseY * mousePitchSensitivity * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -60f, 90f);


        transform.Rotate(0f, mouseYaw, 0f);
        cameraHolder.localRotation = Quaternion.Euler(-pitch, 0f, 0f);
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
