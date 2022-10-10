using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public GameObject[] building;
    public float spawnTime;
    public Transform spawnLocation;
    public float spawntimecooldown = 0f;
    Transform randPosition;



    void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawnTime)
        {
            int randBuilding = Random.Range(0, building.Length);
            spawnLocation.position = new Vector3(spawnLocation.position.x, spawnLocation.position.y + Random.Range(-4.0f, 4f), spawnLocation.position.z);
            Instantiate(building[randBuilding], spawnLocation.position, building[randBuilding].transform.rotation);
            spawntimecooldown = 0f;
        }
    }
}
