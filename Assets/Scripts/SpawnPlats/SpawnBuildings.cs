using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    public GameObject building;
    public float spawnTime;
    public Transform spawnLocation;
    bool initSpawn;

    public Vector2 heightRange = new Vector2(0, 0);
    [SerializeField] private BoxCollider2D _boxCollider;

    void Start()
    {
        // StartCoroutine(SpawnBuilding());
    }

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
            Debug.Log(spawnTime);

            // Spawn a new building at a random height using the building prefab
            Instantiate(building, new Vector3(spawnLocation.position.x, Random.Range(heightRange.x, heightRange.y), spawnLocation.position.z), Quaternion.identity, this.transform);
        }
    }
}
