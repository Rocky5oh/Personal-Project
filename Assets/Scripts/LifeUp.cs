using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUp : MonoBehaviour
{
    public float speed = 60.0f;

    private Rigidbody lifeRb;

    // Start is called before the first frame update
    void Start()
    {
        lifeRb = GetComponent<Rigidbody>();
        transform.position = new Vector3(125, 43, -40);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
