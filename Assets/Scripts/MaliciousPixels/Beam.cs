using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public Transform firePoint;
    public GameObject impactEffect;

    public LineRenderer LineRenderer;
    public LineRenderer LineRenderer2;
    public Collider collide;
    private int damage = 2;
    private float firedown = 1;
    public float spawnMin = 1;
    public float spawnMax = 10;
    public float spawntime = 1f;
    public float spawntimecooldown = 0f;
    public Quaternion spawnrotaion;

    private void Start()
    {
        spawntime = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawntimecooldown += Time.deltaTime;

        if (spawntimecooldown >= spawntime)
        {
            StartCoroutine(Shot());
            spawntime = Random.Range(spawnMin, spawnMax);
            spawntimecooldown = 0f;
        }
        else if (spawntimecooldown >= (spawntime / 2))
        {
            LineRenderer.enabled = false;
            collide.enabled = false;
        }
    }

    IEnumerator Shot()
    {
        LineRenderer2.enabled = true;
        yield return new WaitForSeconds(2f);
        LineRenderer2.enabled = false;
        LineRenderer.enabled = true;
        collide.enabled = true;
        //LineRenderer.enabled = false;

    }

}
