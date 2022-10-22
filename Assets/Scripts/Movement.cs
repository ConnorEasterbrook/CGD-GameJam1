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
    [HideInInspector] public bool crouching = false;
    private bool grounded;
    private bool doubleJumping = false; // Keep track of player double jumping
    private Vector3 velocity;
    public AudioSource jumpSound;
    public AudioSource doubleJumpSound;
    public AudioSource landSound;
    public AudioSource crouchSound;
    private PlayManager playManager;
    public Animator anim;

    private void Awake()
    {
        // Assign controller variable to the Character Controller
        controller = GetComponent<CharacterController>();

        playManager = GetComponent<PlayManager>();
    }

    private void Start()
    {
        // Give currentSpeed variable a value
        currentSpeed = walkSpeed;
    }

    private void Update()
    {
        if (jumping)
        {
            anim.SetBool("IsJumping", true);
        }
        if (!jumping)
        {
            anim.SetBool("IsJumping", false);
        }
        if (crouching)
        {
            anim.SetBool("IsDuck", true);
        }
        if (!crouching)
        {
            anim.SetBool("IsDuck", false);
        }
        if (!playManager.Dead)
        {
            DefaultMovement();
            Crouch();

            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S))
            {
                crouching = false;
                transform.position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2), transform.position.z); // Reset position.
                transform.localScale = new Vector3(2f, 2f, 2f); // Uncrouch the player.
            }

            // Clamp xPos on right to stop the player from going off screen. Left is high clamp so they hit the killbox before going off screen.
            Vector3 pos = transform.position; // Create a new Vector3 variable called pos

            pos.x = Mathf.Clamp(pos.x, -20.5f, 3.5f); // Clamp the player's xPos to allow for limited horizontal movement.
            pos.z = Mathf.Clamp(pos.z, -1, -1); // Clamp the player's zPos to allow for limited vertical movement.
            transform.position = pos; // Set the player's xPos to the new position.
        }
    }

    private void DefaultMovement()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // Move the player right
            velocity.x = walkSpeed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // Move the player left
            velocity.x = -walkSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Establish falling speed. Increase as the falling duration grows
        fallingVelocity -= (gravityForce * Time.deltaTime);

        // Set velocity to match the recorded movement from previous movement sections
        velocity = new Vector3(velocity.x, fallingVelocity, velocity.z);

        // Create new variable to record collision with player movement
        CollisionFlags playerCollision = controller.Move(velocity * Time.deltaTime);

        if (controller.isGrounded && jumping)
        {
            if (doubleJumping)
            {
                landSound.pitch = 0.6f;
                landSound.PlayOneShot(landSound.clip); // Play landing sound
                jumping = false;
                fallingVelocity = 0;
            }
            else
            {
                landSound.pitch = 0.4f;
                landSound.PlayOneShot(landSound.clip); // Play landing sound
                jumping = false;
                // fallingVelocity = 0;
            }
        }
        else if (controller.isGrounded && !jumping)
        {
            fallingVelocity = 0;
        }

        if (!crouching)
        {
            if (Input.GetKeyDown(KeyCode.Space) && doubleJumping)
            {
                grounded = false;
                jumping = true;
                doubleJumping = false;
                fallingVelocity = jumpForce;
                doubleJumpSound.Play();
            }

            // Check for jump input and if true, check that the character isn't jumping or falling. Then call Jump()
            if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
            {
                float sinceLastGrounded = Time.time - lastGroundedTime;
                if (controller.isGrounded || !jumping)
                {
                    Jump();
                }
            }
        }
    }

    // Handles jump movement
    private void Jump()
    {
        grounded = false;
        jumping = true;
        doubleJumping = true;
        fallingVelocity = jumpForce;
        jumpSound.Play();
    }

    private void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S))
        {
            crouchSound.Play();
            crouching = true;
            transform.position = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z); // Adjust for the crouch change to stop falling.
            transform.localScale = new Vector3(2f, 1f, 2f); // Crouch the player.
        }
    }
}
