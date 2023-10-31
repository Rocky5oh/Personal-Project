using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement and Inbound variables
    public float horizontalInput;
    public float speed = 50.0f;
    public float XRange = 73;

    //Player Jumping Variables
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    public GameObject lazerPrefab;

    public bool gameOver = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        //Player remain inbound
        if (transform.position.x < -73)
        {
            transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 73)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
        }
        //Player Jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        //Player Shoots
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(lazerPrefab, transform.position, lazerPrefab.transform.rotation);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

}
