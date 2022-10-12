using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBulletRandom : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnlocation;
    public float spawnMin = 1;
    public float spawnMax = 10;
    public float spawntime = 1f;
    public float spawntimecooldown = 0f;
    public Quaternion spawnrotaion;
    public GameObject parent;

    private void Start()
    {
        spawntime = Random.Range(spawnMin, spawnMax);
    }

    private void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawntime)
        {
            GameObject obstacle = Instantiate(projectile, spawnlocation.position, spawnrotaion);
            obstacle.transform.parent = parent.transform;
            spawntime = Random.Range(spawnMin, spawnMax);
            spawntimecooldown = 0f;
        }
    }

}
