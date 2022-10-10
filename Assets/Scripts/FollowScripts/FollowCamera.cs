using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float smoothTime = 0.15f; // The time it takes to reach the target
    public Transform target; // The target object to follow
    private Vector3 velocity = Vector3.zero; // The velocity of the camera
    private Vector3 targetPosition; // The target position of the camera.
    private Vector3 startPos; // The starting position of the target.
    private int cameraDistance = 3;

    private void Awake()
    {
        startPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Define a target position above and behind the target transform
        targetPosition = new Vector3(transform.position.x, target.position.y + 1.5f, transform.position.z);

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
