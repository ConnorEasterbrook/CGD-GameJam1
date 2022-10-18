using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static public float DifficultySpeed;
    GameObject TimeHandler;

    void Start()
    {
        TimeHandler = GameObject.FindWithTag("Time");
    }

    private void Update()
    {
        DifficultySpeed = TimeHandler.GetComponent<UniversalTimeController>().initialTime;
        Debug.Log(DifficultySpeed);
    }
}
