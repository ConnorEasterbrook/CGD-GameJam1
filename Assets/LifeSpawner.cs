using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject lifePickup;
    [SerializeField] private GameObject spawnLocation;
    private float spawnCountdown = 1.0f;
    private bool spawned = false;

    private void Start()
    {
        spawned = true;
    }

    private void GenSpawnCountdown()
    {
        if (spawned)
        {
            spawnCountdown = Random.RandomRange(10.0f, 20.0f);
            spawned = false;
        }
    }

    private void Countdown()
    {
        if (spawnCountdown <= 0)
        {
            SpawnObject();
        }

        else
        {
            spawnCountdown -= Time.deltaTime;
        }
    }

    private void SpawnObject()
    {
        spawned = true;
        Instantiate(lifePickup, spawnLocation.transform);
    }
    
    private void Update()
    {
        GenSpawnCountdown();
        Countdown();
    }
}
