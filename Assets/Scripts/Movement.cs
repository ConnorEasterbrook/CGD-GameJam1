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
        CheckGrounded(); // Check if the player is grounded
        JumpStrength(); // Check how long the player is holding the jump button

        playerRigidbody.AddForce(Vector2.down * gravity);
    }

    /// <summary>
    /// Checks if the player is grounded
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
    /// Checks how long the player is holding the jump button
    /// </summary>
    private void JumpStrength()
    {
        if (Input.GetButton("Jump") && grounded)
        {
            jumpCharge += 5 * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump") && grounded)
        {
            jumpCharge = Mathf.Clamp(jumpCharge, 0, 1.75f);
            float jumpPower = jumpForce * jumpCharge;

            Debug.Log(jumpPower);

            jumpCharge = 0.5f;
            playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }
}
