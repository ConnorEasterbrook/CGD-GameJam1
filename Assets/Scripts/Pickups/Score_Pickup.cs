using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Pickup : MonoBehaviour
{
    public int scoreFromPickup = 20;
    

    private void OnTriggerEnter(Collider other)
    {
        ScoreOverTime.score += scoreFromPickup;
        Destroy(gameObject);
    }
}
