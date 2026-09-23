using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float sprintSpeed = 5f;
    
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float sprintJumpBoost = 3f;

    [SerializeField] Camera playerCamera;

    [SerializeField] float normalFOV = 60f;
    [SerializeField] float sprintFOV = 75f;

    [SerializeField] float fovSmoothSpeed = 8f;

    [SerializeField] float gravity = -9.8f;

    float verticalVelocity;

    CharacterController controller;



    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");     

        Vector3 move = transform.forward * vertical + transform.right * horizontal;
        move = move.normalized;
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) && vertical > 0;

        float currentSpeed = moveSpeed;
        float targetFOV = normalFOV;

        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
            targetFOV = sprintFOV;
        }
        playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, targetFOV, fovSmoothSpeed * Time.deltaTime);

        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }   
        
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(-2*gravity*jumpHeight);
            if(isSprinting)
            {
                verticalVelocity += sprintJumpBoost;
            }
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 finalMove = move * currentSpeed;
        finalMove.y = verticalVelocity;
        
        controller.Move(finalMove * Time.deltaTime);
    }
}
