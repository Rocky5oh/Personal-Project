using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class BulletController : MonoBehaviour
{
    //Speed of Bullet
    [SerializeField] private float _spd = 15.0f;

    private void update()
    {
        //Call Bullet Method
        BulletMovement();
    }

    private void BulletMovement()
    {
        //Set bullet direction
        Vector3 bulletVelocity = Vector3.forward * _spd;
        //Move Bullet based on Time
        transform.Translate(bulletVelocity * Time.deltaTime);
    }
}
