using Unity.Mathematics;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpHeight = 2f;
    [SerializeField] float sprintSpeed = 5f;

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

        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && vertical > 0)
        {
            currentSpeed = sprintSpeed;
        }       

        if (controller.isGrounded == true && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }   
        
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(-2*gravity*jumpHeight);
            Debug.Log(jumpHeight);
        }


        verticalVelocity += gravity * Time.deltaTime;

        Vector3 finalMove = move * currentSpeed;
        finalMove.y = verticalVelocity;
        
        controller.Move(finalMove * Time.deltaTime);
    }
}
