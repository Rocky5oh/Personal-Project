using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBoundsBattery : MonoBehaviour
{
    private float leftBound = -90;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
