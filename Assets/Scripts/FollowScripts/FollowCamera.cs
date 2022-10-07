using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float smoothTime = 0.15f; // The time it takes to reach the target
    public Transform target; // The target object to follow
    private Vector3 velocity = Vector3.zero; // The velocity of the camera

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 0)
        {
            // Define a target position above and behind the target transform
            Vector3 targetPosition = target.TransformPoint(new Vector3(0, 3, -9));

            // Smoothly move the camera towards that target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else
        {
            // Stop camera from clipping under the level
            transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
