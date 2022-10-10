using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public GameObject building;
    public float spawnTime;
    public Transform spawnLocation;
    public float spawntimecooldown = 0f;
    Transform randPosition;



    void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawnTime)
        {
            spawnLocation.position = new Vector3(spawnLocation.position.x, spawnLocation.position.y + Random.Range(-5.0f, 5f), spawnLocation.position.z);
            Instantiate(building, spawnLocation.position, building.transform.rotation);
            spawntimecooldown = 0f;
        }
    }
}
