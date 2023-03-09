using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public float DifficultySpeed;

    void Awake()
    {
        Application.targetFrameRate = 20;
    }

    private void Update()
    {
        DifficultySpeed = UniversalTimeController.initialTime;
    }
}
