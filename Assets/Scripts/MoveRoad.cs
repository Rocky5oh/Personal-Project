using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveRoad : MonoBehaviour
{
    private float speed = 70f;

    public GameManager gameManager;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);



        if(isGameActive == false)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        }

    }
}
