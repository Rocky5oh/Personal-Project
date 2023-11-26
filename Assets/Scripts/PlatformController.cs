using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 50.0f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private Rigidbody platformRb;


    // Start is called before the first frame update
    void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(77, Random.Range(0, 30));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
