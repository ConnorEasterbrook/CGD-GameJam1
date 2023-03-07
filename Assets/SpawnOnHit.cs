using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnHit : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Vector2 heightRange = new Vector2(0, 0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("SpawnOnHit: OnTriggerEnter2D");
            Instantiate(spawnObject, new Vector2(spawnPoint.position.x, Random.Range(heightRange.x, heightRange.y)), Quaternion.identity, spawnPoint);
        }
    }
}
