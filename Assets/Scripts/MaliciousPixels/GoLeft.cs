using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{
    // private int damage = 10;
    public static float moveSpeed = 2f;

    void Update()
    {
        transform.position -= (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
    }
}
