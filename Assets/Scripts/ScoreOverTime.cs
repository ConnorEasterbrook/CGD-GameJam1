using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOverTime : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public float score;
    public float scoreOverTimeIncrease;

    // Update is called once per frame
    void Update()
    {
        Score.SetText(score.ToString("F0"));
        score += scoreOverTimeIncrease * Time.deltaTime * 0.5f;
    }
}
