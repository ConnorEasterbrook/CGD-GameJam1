using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public GameObject[] building;
    public float spawnTime;
    float spawnTimeMultiplier;
    public Transform spawnLocation;
    public float spawntimecooldown = 0f;
    bool initSpawn;

    void Update()
    {
        spawntimecooldown += Time.deltaTime;

        spawnTimeMultiplier = (GoLeft.moveSpeed * Manager.DifficultySpeed);

        if (spawntimecooldown >= (spawnTime / spawnTimeMultiplier))
        {
            int randBuilding = Random.Range(0, building.Length);
            spawnLocation.position = new Vector3(spawnLocation.position.x, spawnLocation.position.y + Random.Range(-4.0f, 4f), spawnLocation.position.z);
            GameObject skyscraper = Instantiate(building[randBuilding], spawnLocation.position, building[randBuilding].transform.rotation);
            skyscraper.transform.parent = gameObject.transform;
            spawntimecooldown = 0f;
        }
    }
}
