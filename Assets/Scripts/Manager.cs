using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public float DifficultySpeed = 1f;

    private void Update()
    {
        DifficultySpeed += (Time.deltaTime /80);
        //Debug.Log(DifficultySpeed);
    }
}
