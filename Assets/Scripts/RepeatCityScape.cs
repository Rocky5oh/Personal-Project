using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatCityScape : MonoBehaviour
{
    private Vector3 startingPos;
    private float repeatLength;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startingPos.z - repeatLength)
        {
            transform.position = startingPos;
        }
    }
}
