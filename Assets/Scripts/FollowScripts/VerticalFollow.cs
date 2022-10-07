using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFollow : MonoBehaviour
{
    public Transform target; // The target object to follow

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3 (transform.position.x, target.position.y, transform.position.z); // Follow the player's yPos.
        transform.position = pos;
    }
}
