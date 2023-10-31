using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject lazerPrefab;

    public float bulletForce = 150.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject lazer = Instantiate(lazerPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = lazer.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
