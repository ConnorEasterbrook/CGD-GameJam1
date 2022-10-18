using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOverTime : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public float score;
    private float timeChange;
    GameObject TimeHandler;

    void Start()
    {
        TimeHandler = GameObject.FindWithTag("Time");
    }
    // Update is called once per frame
    void Update()
    {
        timeChange = TimeHandler.GetComponent<UniversalTimeController>().initialTime;
        Score.SetText(score.ToString("F0"));
        score += timeChange * Time.deltaTime;
    }
}
