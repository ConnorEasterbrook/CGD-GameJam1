using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoLeft : MonoBehaviour
{
    // private int damage = 10;
    public static float moveSpeed = 5f;
    public float destroyTimer = 10f;

    private void Start()
    {
        StartCoroutine(DestroyAfterFiveSeconds());
    }

    void Update()
    {
        transform.position += (moveSpeed * Manager.DifficultySpeed) * transform.right * Time.deltaTime;
    }

    private IEnumerator DestroyAfterFiveSeconds()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(gameObject);
    }
}
