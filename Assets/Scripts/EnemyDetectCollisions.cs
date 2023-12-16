using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private PlayerController playerController;

    public ParticleSystem explosionParticle;

    public AudioSource explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.AddLives(-1);
            playerController.AddLives(-1);
            explosionParticle.Play();
            Destroy(gameObject);
            explosionSound.Play();
            //gameManager.GameOver();
        }
    }
}
