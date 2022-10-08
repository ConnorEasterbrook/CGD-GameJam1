using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{
    private int damage = 10;
    public float moveSpeed = 2f;

    private void Start()
    {
        Destroy(gameObject, 15f);
    }

    void Update()
    {
        transform.position += moveSpeed * transform.right * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
