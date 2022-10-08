using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    private float offset; // The offset between the target and the object

    private void Awake() 
    {
        offset = transform.position.x - target.position.x; // Get the offset between the target and the object
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3 (target.position.x + offset, transform.position.y, transform.position.z); // Follow the player's yPos.
        transform.position = pos;
    }
}
