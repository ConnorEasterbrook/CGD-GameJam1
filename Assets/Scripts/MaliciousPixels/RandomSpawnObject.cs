using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnObject : MonoBehaviour
{
    public GameObject[] projectiles;
    public Transform spawnlocation;
    public float spawntime = 0.5f;
    public float spawntimecooldown = 0f;
    public Quaternion spawnrotaion;

    private void Start()
    {
        projectiles = Resources.LoadAll<GameObject>("MaliciousPixels/RandomObjects");
    }

    private void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawntime)
        {
            Instantiate(projectiles[Random.Range(0, projectiles.Length)], spawnlocation.position, spawnrotaion);
            spawntimecooldown = 0f;
        }
    }
}
