using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Death: OnTriggerEnter");
            other.gameObject.GetComponent<PlayManager>().UpdateDeath();
        }
    }
}
