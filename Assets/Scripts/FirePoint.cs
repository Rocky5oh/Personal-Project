using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
    private AudioSource fireGunAudio;
    public AudioClip lazerSound;
    public GameManager gameManager;
    public Animator anim;

    public GameObject lazerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        fireGunAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(lazerPrefab, transform.position, lazerPrefab.transform.rotation);
            anim.SetBool("shoot", true);
        }
        else
        {
            anim.SetBool("shoot", false);
        }
    }
}
