using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Pickup : MonoBehaviour
{
    public int scoreFromPickup = 20;
    private bool canGivePoints = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && canGivePoints)
        {
            ScoreOverTime.score += scoreFromPickup;
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().enabled=false;
            canGivePoints=false;
            Destroy(gameObject,5f);
        }
    }
}
