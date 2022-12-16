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

    void Start()
    {
        StartCoroutine(SpawnBuilding());
    }

    // void Update()
    // {
    //     spawntimecooldown += Time.deltaTime;

    //     spawnTimeMultiplier = (GoLeft.moveSpeed * Manager.DifficultySpeed);

    //     if (spawntimecooldown >= (spawnTime / spawnTimeMultiplier))
    //     {
    //         int randBuilding = Random.Range(0, building.Length);
    //         spawnLocation.position = new Vector3(spawnLocation.position.x, spawnLocation.position.y + Random.Range(-1.0f, 1f), spawnLocation.position.z);
    //         GameObject skyscraper = Instantiate(building[randBuilding], spawnLocation.position, building[randBuilding].transform.rotation);
    //         spawntimecooldown = 0f;
    //     }
    // }

    private IEnumerator SpawnBuilding()
    {
        yield return new WaitForSeconds(spawnTime);
        int randBuilding = Random.Range(0, building.Length);
        spawnLocation.position = new Vector3(spawnLocation.position.x, spawnLocation.position.y + Random.Range(-1.0f, 1f), spawnLocation.position.z);
        GameObject skyscraper = Instantiate(building[randBuilding], spawnLocation.position, building[randBuilding].transform.rotation);
        StartCoroutine(SpawnBuilding());
    }
}
