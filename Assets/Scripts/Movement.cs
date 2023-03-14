using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Essential Movement Variables
    private Rigidbody2D controller;

    [Header("Player Movement")]
    public float walkSpeed = 5.0f;
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

    private void Update()
    {
        if(playManager.Dead)
        {
            return;
        }

        if(jumping)
        {
            anim.SetBool("IsJumping", true);
        }
        if(!jumping)
        {
            anim.SetBool("IsJumping", false);
        }
        if(crouching)
        {
            anim.SetBool("IsDuck", true);
        }
        if(!crouching)
        {
            anim.SetBool("IsDuck", false);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            jumping = true;
            controller.gravityScale = gravityForce;
            controller.velocity += new Vector2(0f, jumpForce);
            jumpSound.Play();
        }
        else if(Input.GetKeyDown(KeyCode.Space) && jumping && !doubleJumping)
        {
            doubleJumping = true;
            controller.gravityScale = gravityForce;
            controller.velocity += new Vector2(0f, jumpForce);
            doubleJumpSound.Play();
        }
    }

    private void FixedUpdate()
    {
        float time = Time.time * 20f;
        float stutter = Mathf.Sin(time) * 0.5f + 0.5f;
        controller.gravityScale = gravityForce * stutter;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(doubleJumping)
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
    }
}
