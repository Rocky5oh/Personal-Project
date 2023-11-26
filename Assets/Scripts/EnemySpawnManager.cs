using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private Rigidbody enemyRb;

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private float spawnRangeX = 77.0f;
    private float spawnRangeZ = 0f;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(77, Random.Range(0, 30));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
