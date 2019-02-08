using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horiMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horiMovement, 0.0f, vertMovement);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}