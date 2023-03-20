using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{
    // private int damage = 10;
    public static float moveSpeed = 4f;

    private void OnEnable()
    {
        StartCoroutine(moveLeft());
    }

    /*void Update()
    {
        transform.position -= (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
    }*/

    private IEnumerator moveLeft()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.25f);
            transform.position -= (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
        }
    }
}
