using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    public float horizontalInput;
    public float speed = 50.0f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;


    public float XRange = 73;

    public GameObject projectilePrefab;

    //Jumping variables
    private Rigidbody2D playerRb;
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;

    //Flipping player variable
    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //Player movement

        movement.x = Input.GetAxis("Horizontal");
        //Player remain inbound
        if(transform.position.x < -73)
        {
            transform.position = new Vector2(-XRange, transform.position.y);
        }

        if(transform.position.x > 73)
        {
            transform.position = new Vector2(XRange, transform.position.y);
        }
        //Launch bullet from player
        if(Input.GetKey(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        //Player Jumping
        if(Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        cam.ScreenToWorldPoint(Input.mousePosition);

    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
