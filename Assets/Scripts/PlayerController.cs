using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 50.0f;
    public float XRange = 73;

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Player remain inbound
        if(transform.position.x < -73)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x > 73)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        }
        //Launch bullet from player
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
