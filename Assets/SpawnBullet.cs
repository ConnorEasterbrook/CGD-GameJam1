using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnlocation;
    public float spawntime = 0.5f;
    public float spawntimecooldown = 0f;
    public Quaternion spawnrotaion;

    private void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if(spawntimecooldown >= spawntime)
        {
            Instantiate(projectile, spawnlocation.position, spawnrotaion);
            spawntimecooldown = 0f;
        }
    }

}

