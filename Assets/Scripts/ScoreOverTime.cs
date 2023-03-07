using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreOverTime : MonoBehaviour
{
    public TextMeshProUGUI Score;
    static public float score;
    private float timeChange;

    // Update is called once per frame
    void Update()
    {
        timeChange = UniversalTimeController.initialTime;
        Score.SetText(score.ToString("F0"));
        score += timeChange * Time.deltaTime;
    }
}
