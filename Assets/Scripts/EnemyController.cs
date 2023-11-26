using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject lazerPrefab;
    private float startDelay = 1;
    private float spawnInterval = 1.5f;

    public float speed = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyBullet", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    public void SpawnEnemyBullet()
    {
        Instantiate(lazerPrefab, transform.position, lazerPrefab.transform.rotation);
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
