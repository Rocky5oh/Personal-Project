using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float rightBound = 80;
    private float leftBound = -80;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightBound)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
