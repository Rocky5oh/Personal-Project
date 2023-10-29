using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 50.0f;
    public float XRange = 73;

    public GameObject projectilePrefab;

    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;

    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
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
        //Player Jumping
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        //Flip Player
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x += -3;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
