using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variables to set speed, jump force, and sprint multiplier
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 7f;

    // Camera and input
    public Transform cameraTransform;

    // Private variables
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down

        // Calculate direction relative to the camera
        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        moveDirection.y = 0; // Keep the movement on the XZ plane
        moveDirection.Normalize();

        // Apply speed (walk or sprint)
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        // Move the player
        Vector3 movement = moveDirection * speed * Time.deltaTime;
        transform.position += movement;

        // Rotate player to face movement direction (if moving)
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

}

