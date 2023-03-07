using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public float DifficultySpeed;

    private void Update()
    {
        DifficultySpeed = UniversalTimeController.initialTime;
    }
}
