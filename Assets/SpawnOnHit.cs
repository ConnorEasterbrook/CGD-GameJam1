using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnHit : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject[] spawnObject;
    [SerializeField] private Vector2 heightRange = new Vector2(0, 0);

    [SerializeField] private GameObject startingHouse;
    private float heightCheck;

    private void Start()
    {
        heightCheck = startingHouse.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            int randomBuilding = Random.Range(0, spawnObject.Length);
            float randHeight = Random.Range(heightRange.x, heightRange.y);

            // Calculate the difference between randHeight and heightCheck
            float difference = randHeight - heightCheck;
            Debug.Log("Difference: " + difference);

            if (difference > 6 || difference < -6)
            {
                if (heightCheck + 6 > heightRange.y) 
                {
                    randHeight = heightCheck - 4;
                    heightCheck = randHeight;
                }
                else if (heightCheck - 6 < heightRange.x)
                {
                    randHeight = heightCheck + 4;
                    heightCheck = randHeight;
                }
                else
                {
                    randHeight = heightCheck + Random.Range(-6, 6);
                    heightCheck = randHeight;
                }
            }
            else
            {
                heightCheck = randHeight;
            }

            Instantiate(spawnObject[randomBuilding], new Vector2(spawnPoint.position.x, randHeight), Quaternion.identity, spawnPoint);
        }
    }
}
