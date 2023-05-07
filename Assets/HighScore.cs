using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI hiScore;
    public int score;

    void Start()
    {
        score = PlayerPrefs.GetInt("HighScore");
        hiScore.text = score.ToString();
    }
    public void setScore(int Score)
    {
        PlayerPrefs.SetInt("HighScore", Score);
        hiScore.text = score.ToString();
    }
}
