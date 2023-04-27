using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Pickup : MonoBehaviour
{
    public int scoreFromPickup = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            ScoreOverTime.score += scoreFromPickup;
            Destroy(gameObject);
        }
    }
}
