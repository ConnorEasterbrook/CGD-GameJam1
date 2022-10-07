using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpForce = 10f;
    private float jumpCharge = 0f;
    private float gravity = 2f;
    private Rigidbody playerRigidbody;
    private bool grounded = true;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGrounded(); // Check if the player is grounded.
        JumpStrength(); // Check how long the player is holding the jump button.

        playerRigidbody.AddForce(Vector2.down * gravity); // Add gravity to the player.
        playerRigidbody.MovePosition(transform.position + Vector3.left * 2f * Time.deltaTime);

        // Clamp the player's xPos to allow for limited horizontal movement.
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -5.0f, 3.0f);
        transform.position = pos;

        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.MovePosition(transform.position + Vector3.right * 20f * Time.deltaTime); // Move the player right.
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.MovePosition(transform.position + Vector3.left * 20f * Time.deltaTime); // Move the player left.
        }
    }

    /// <summary>
    /// Checks if the player is grounded.
    /// </summary>
    private void CheckGrounded()
    {
        if (playerRigidbody.velocity.y == 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    /// <summary>
    /// Checks how long the player is holding the jump button.
    /// </summary>
    private void JumpStrength()
    {
        // Upon pressing the jump button, charge up the jump.
        if (Input.GetButton("Jump") && grounded)
        {
            jumpCharge += 5 * Time.deltaTime;
        }

        // If the player is grounded and the jump button is released, jump.
        if (Input.GetButtonUp("Jump") && grounded)
        {
            jumpCharge = Mathf.Clamp(jumpCharge, 0, 1.75f); // Clamp the jump charge to prevent the player from jumping too high.
            float jumpPower = jumpForce * jumpCharge; // Calculate the jump power.
            jumpCharge = 0.5f; // Reset the jump charge.
            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse); // Jump.
        }
    }
}
