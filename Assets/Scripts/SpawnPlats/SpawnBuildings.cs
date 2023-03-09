using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public float spawnTime;
    public Transform spawnLocation;
    bool initSpawn;
    public Vector2 heightRange = new Vector2(-30, -22);
    public GameObject[] building;

    void Update()
    {
        // Make spawn time relative to the speed of the game. Game speeds up so spawn time decreases
        float spawnTimeMultiplier = UniversalTimeController.initialTime;
        spawnTime = 4f / spawnTimeMultiplier;
    }

    private IEnumerator SpawnBuilding()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            int buildingIndex = Random.Range(0, building.Length);

            // Spawn a new building at a random height using the building prefab
            Instantiate(building[buildingIndex], new Vector3(spawnLocation.position.x, Random.Range(heightRange.x, heightRange.y), spawnLocation.position.z), Quaternion.identity, this.transform);
        }
    }
}
