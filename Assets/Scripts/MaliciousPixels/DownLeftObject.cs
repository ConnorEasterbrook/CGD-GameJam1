using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownLeftObject : MonoBehaviour
{
    private int damage = 10;
    public float moveSpeed = 2f;

    private void Start()
    {
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        //change = moveSpeed * Manager.DifficultySpeed;
        //transform.position += (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
        transform.Translate(Random.Range(0.5f,2f) * Time.deltaTime, moveSpeed * Manager.DifficultySpeed * Time.deltaTime, 0f);
        //transform.position = transform.position + new Vector3(0f, change * Time.deltaTime, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
