using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //Movement and Inbound variables
    public float horizontalInput;
    public float speed = 50.0f;
    public float XRange = 68;

    //Player Jumping Variables
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;

    public GameObject lazerPrefab;

    public bool gameOver = false;

   
    public float moveSpeed = 5f;
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    public GameManager gameManager;

    public Animator anim;

    void Start()
    {
       playerRb = GetComponent<Rigidbody>();

       Vector3 storePhysicsDefault = new Vector3(0, -9.81f, 0);
       Physics.gravity = storePhysicsDefault * gravityModifier;
    }

    void Update()
    {
        playerRb = GetComponent<Rigidbody> ();

        //Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        anim.SetFloat("horizontal", horizontalInput);
        //Player remain inbound
        if (transform.position.x < -70)
         {
             transform.position = new Vector3(-XRange, transform.position.y, transform.position.z);
         }
         if (transform.position.x > 70)
         {
             transform.position = new Vector3(XRange, transform.position.y, transform.position.z);
         }
        //Player Jumps
         if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
         {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetBool("jump", true);

        }
         else
        {
            anim.SetBool("jump", false);
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy Lazer"))
        {
            gameManager.AddLives(-1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
