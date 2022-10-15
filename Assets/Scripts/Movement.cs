using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Essential Movement Variables
    private CharacterController controller;

    [Header("Player Movement")]
    public float walkSpeed = 5.0f;
    private float currentSpeed; // For determining our speed in code
    public float jumpForce = 10.0f;
    public float gravityForce = 20.0f;
    private float fallingVelocity = 0.0f; // Keep track of falling speed
    private float lastGroundedTime = 0.0f; // Keep track of when last grounded
    [HideInInspector] public bool jumping = false; // Keep track of player jumping
    [HideInInspector] public bool crouching;
    private bool doubleJumping = false; // Keep track of player double jumping
    private Vector3 velocity;

    private void Awake()
    {
        // Assign controller variable to the Character Controller
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        // Give currentSpeed variable a value
        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        DefaultMovement();
        Crouch();

        // Clamp xPos on right to stop the player from going off screen. Left is high clamp so they hit the killbox before going off screen.
        Vector3 pos = Vector3.zero; // Create a new Vector3 variable called pos
        pos.x = Mathf.Clamp(transform.position.x, -10.5f, 3.5f); // Clamp the player's xPos to allow for limited horizontal movement.
        transform.position = pos; // Set the player's xPos to the new position.
    }

    private void DefaultMovement()
    {
        // Create a new Vector2 variable that takes in our movement inputs
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Normalize the Vector2 input variable and make it a Vector3. Then transform the input to move in world space.
        Vector3 inputDirection = new Vector3(input.x, 0, 0).normalized;
        Vector3 inputDirectionWorld = transform.TransformDirection(inputDirection);

        // Create a new Vector3 that takes in our world movement and current speed to then use in a movement smoothing calculation
        Vector3 targetVelocity = inputDirectionWorld * currentSpeed;
        velocity = targetVelocity;

        // Establish falling speed. Increase as the falling duration grows
        fallingVelocity -= gravityForce * Time.deltaTime;

        // Set velocity to match the recorded movement from previous movement sections
        velocity = new Vector3(velocity.x, fallingVelocity, velocity.z);

        // Create new variable to record collision with player movement
        controller.Move(velocity * Time.deltaTime);

        // If there is collision below the player (ground)
        if (controller.isGrounded)
        {
            jumping = false; // Set jumping to false
            doubleJumping = false; // Set doubleJumping to false
            fallingVelocity = 0; // Stop fallingVelocity
        }

        if (Input.GetKeyDown(KeyCode.Space) && doubleJumping)
        {
            jumping = true;
            doubleJumping = false;
            fallingVelocity = jumpForce;
        }

        // Check for jump input and if true, check that the character isn't jumping or falling. Then call Jump()
        if (Input.GetKey(KeyCode.Space))
        {
            float sinceLastGrounded = Time.time - lastGroundedTime;
            if (controller.isGrounded || !jumping)
            {
                Jump();
            }
        }
    }

    // Handles jump movement
    private void Jump()
    {
        jumping = true;
        doubleJumping = true;
        fallingVelocity = jumpForce;
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z); // Adjust for the crouch change to stop falling.
            transform.localScale = new Vector3(1f, 0.5f, 1f); // Crouch the player.
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); // Reset position.
            transform.localScale = new Vector3(1f, 1f, 1f); // Uncrouch the player.
        }
    }
}
