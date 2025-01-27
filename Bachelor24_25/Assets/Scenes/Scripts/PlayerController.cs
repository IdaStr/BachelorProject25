using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement variables
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 7f;

    // Camera follow variables
    public Transform cameraTransform; // Reference to the camera
    public Transform cameraFollowTarget; // Target for the camera to follow
    public float cameraFollowSpeed = 5.0f;

    // Rotation variables
    public float rotationSpeed = 10f;

    // Private variables
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody has constraints to prevent tipping
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down

        // Calculate direction relative to the camera
        Vector3 direction = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        direction.y = 0; // Keep movement on the XZ plane
        direction.Normalize();

        if (direction.magnitude > 0.1f)
        {
            // Rotate the player towards the movement direction
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Determine speed (sprint or walk)
        float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        // Move the player
        Vector3 movement = direction * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if grounded
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("collision");
            isGrounded = true;
        }
    }
}
