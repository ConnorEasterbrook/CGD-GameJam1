using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFollow : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3 (transform.position.x, target.position.y, transform.position.z);
        transform.position = pos;
    }
}
