using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{
    private int damage = 10;
    static public float moveSpeed = 1f;
    public float destroyTimer = 20f;

    private void Start()
    {
        Destroy(gameObject, destroyTimer);
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
