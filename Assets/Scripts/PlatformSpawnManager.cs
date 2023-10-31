using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;

    private float startDelay = 1;
    private float spawnInterval = 1.5f;

    private float spawnRangeX = 77.0f;
    private float spawnRangeZ = 0f;

    public float sideSpawnMinZ;
    public float sideSpawnMaxZ;
    public float sideSpawnX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPlatform", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomPlatform()
    {
        int platformIndex = Random.Range(0, platformPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnRangeX, Random.Range(2, 50), spawnRangeZ);

        Instantiate(platformPrefabs[platformIndex], spawnPos, platformPrefabs[platformIndex].transform.rotation);
    }

}
