using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.MeshOperations;

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

    //FOR IDAS ANIMATION (STARTS).
        [SerializeField] private Vector3 moveDirection;
        private Animator animator;
        private CharacterController controller;
        private int _animIDSpeed;
    //IDAS ANIMATION STUFF ENDS HERE



    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody has constraints to prevent tipping
        rb.freezeRotation = true;

        //FOR IDA ANIMATION (STARTS)
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        _animIDSpeed = Animator.StringToHash("Speed");
        //IDAS ANIMATION STUFF ENDS HERE

    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        //AnimatedMovement();

        //Ida animation stuff. Delete if it breaks anything
        
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                animator.SetBool("InteractionAnim", true);
            }
            else 
            {
                animator.SetBool("InteractionAnim", false);
            }
        }
        //Ida animation stuff ENDS

    }
    //IDA ANIMATION STUFF. Delete this if I am messing up stuff! (STARTS)
    private void AnimatedMovement()
    {
        {
            //Animation
            if (moveDirection == Vector3.zero)
            {
                //Idle
                animator.SetFloat(_animIDSpeed, 0);

            }
            else if(!Input.GetKey(KeyCode.LeftShift))
            {
                //Walk
                animator.SetFloat(_animIDSpeed, 7);
            }
            else
            {
                //Run
                animator.SetFloat(_animIDSpeed, 3);
            }
        }

        
    }
    // IDA ANIMATION STUFF ENDS HERE

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

        transform.position = transform.position + movement;


        if (direction == Vector3.zero)
        {
            //Idle
            animator.SetFloat(_animIDSpeed, 1);

        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            //Walk
            animator.SetFloat(_animIDSpeed, 3);
        }
        else
        {
            //Run
            animator.SetFloat(_animIDSpeed, 7);
        }
        print(direction);
        //rb.MovePosition(transform.position + movement);
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
  
