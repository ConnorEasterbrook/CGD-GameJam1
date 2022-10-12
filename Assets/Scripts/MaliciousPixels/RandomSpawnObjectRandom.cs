using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObjectRandom : MonoBehaviour
{
    public GameObject[] projectiles;
    public Transform spawnlocation;
    public float spawnMin = 1;
    public float spawnMax = 10;
    public float spawntime = 1f;
    public float spawntimecooldown = 0f;
    public Quaternion spawnrotaion;

    private void Start()
    {
        projectiles = Resources.LoadAll<GameObject>("MaliciousPixels/RandomObjects");
        spawntime = Random.Range(spawnMin, spawnMax);
    }

    private void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawntime)
        {
            Instantiate(projectiles[Random.Range(0, projectiles.Length)], spawnlocation.position, spawnrotaion);
            spawntime = Random.Range(spawnMin, spawnMax);
            spawntimecooldown = 0f;
        }
    }
}
