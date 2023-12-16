using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveRoad : MonoBehaviour
{
    private float speed = 70f;

    public GameManager gameManager;

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
            movingRoad();

        }
 



        if(gameManager.isGameActive == false)
        {
            stopRoad();
        }

    }

    void movingRoad()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    void stopRoad()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
