using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTimeController : MonoBehaviour
{
    public static float initialTime = 0.1f;
    public float DEBUGTIME;
    public float timeIncrease;
    // Update is called once per frame
    void Update()
    {
        DEBUGTIME = initialTime;

        initialTime += timeIncrease * Time.deltaTime;
        Mathf.Clamp(initialTime, 0, 15);
    }
}
