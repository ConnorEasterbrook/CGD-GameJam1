using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Essential Movement Variables
    private Rigidbody2D controller;

    [Header("Player Movement")]
    public float walkSpeed = 5.0f;
    private float currentSpeed; // For determining our speed in code
    public float jumpForce = 10.0f;
    public float gravityForce = 9.81f;
    [HideInInspector] public bool jumping = false; // Keep track of player jumping
    [HideInInspector] public bool crouching = false;
    private bool doubleJumping = false; // Keep track of player double jumping
    public AudioSource jumpSound;
    public AudioSource doubleJumpSound;
    public AudioSource landSound;
    public AudioSource crouchSound;
    private PlayManager playManager;
    public Animator anim;

    private void Awake()
    {
        // Assign controller variable to the Character Controller
        controller = GetComponent<Rigidbody2D>();

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
            // Crouch();

            // if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.S))
            // {
            //     crouching = false;
            //     transform.position = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y / 2), transform.position.z); // Reset position.
            //     transform.localScale = new Vector3(2f, 2f, 2f); // Uncrouch the player.
            // }
        }
    }

    private void FixedUpdate()
    {
        float time = Time.time * 20f;
        float stutter = Mathf.Sin(time) * 0.5f + 0.5f;
        controller.gravityScale = gravityForce * stutter;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.velocity += new Vector2(0f, jumpForce * stutter);
        }
    }

    private void DefaultMovement()
    {
        // Check for jump input and if true, check that the character isn't jumping or falling. Then call Jump()
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            controller.velocity += new Vector2(0, jumpForce);
            jumpSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !doubleJumping)
        {
            doubleJumping = true;
            controller.velocity += new Vector2(0, jumpForce);
            doubleJumpSound.Play();
        }
    }

    // private void Crouch()
    // {
    //     if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.S))
    //     {
    //         crouchSound.Play();
    //         crouching = true;
    //         transform.position = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z); // Adjust for the crouch change to stop falling.
    //         transform.localScale = new Vector3(2f, 1f, 2f); // Crouch the player.
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Ground")
        // {
        if (doubleJumping)
        {
            landSound.pitch = 0.6f;
        }
        else
        {
            landSound.pitch = 0.4f;
        }

        landSound.PlayOneShot(landSound.clip); // Play landing sound
        jumping = false;
        doubleJumping = false;
        // }
        // else if (collision.gameObject.tag == "Building")
        // {

        // }
    }
}
