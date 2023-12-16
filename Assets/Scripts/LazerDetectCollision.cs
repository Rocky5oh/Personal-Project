using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDetectCollision : MonoBehaviour
{

    private GameManager gameManager;
    public int pointValue;

    private AudioSource destroyEnemyAudio;
    public AudioClip explosionSound;

    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        destroyEnemyAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(pointValue);
            destroyEnemyAudio.PlayOneShot(explosionSound, 1.0f);
            explosionParticle.Play();
        }
    }
}
