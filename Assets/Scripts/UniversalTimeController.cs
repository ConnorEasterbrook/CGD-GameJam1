using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalTimeController : MonoBehaviour
{
    public float initialTime;
    public float timeIncrease;
    public float rateOfIncrease;
    // Update is called once per frame
    void Update()
    {
        initialTime += timeIncrease * Time.deltaTime * rateOfIncrease;
    }
}
