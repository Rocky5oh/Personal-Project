using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20f;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive == true)
        {
            MoveCityScape();
        }

        else if (gameManager.isGameActive == false)
        {
            Stop();
        }
    }

    void MoveCityScape()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    void Stop()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
