using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpSpawnManager : MonoBehaviour
{
    public GameObject[] lifePrefabs;

    private float startDelay = 5;
    private float spawnInterval = 6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLifeUp", startDelay, spawnInterval);
        transform.position = new Vector3(10, 43, -20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnLifeUp()
    {
        int lifeIndex = Random.Range(0, lifePrefabs.Length);
        Vector3 spawnPos = new Vector3(125, 43, -20);

        Instantiate(lifePrefabs[lifeIndex], spawnPos, lifePrefabs[lifeIndex].transform.rotation);
    }
}
