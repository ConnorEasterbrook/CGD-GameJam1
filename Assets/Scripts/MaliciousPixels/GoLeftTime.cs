using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeftTime : MonoBehaviour
{
    private int damage = 10;
    public float moveSpeed = 2f;

    private void Start()
    {
        Destroy(gameObject, 20f);
    }

    void Update()
    {
        transform.position += (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
