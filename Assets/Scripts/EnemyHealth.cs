using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public int amountToDestroy;

    private int currentHealthAmount = 0;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = amountToDestroy;
        healthSlider.value = 0;
        healthSlider.fillRect.gameObject.SetActive(false);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyEnemy(int amount)
    {
        currentHealthAmount += amount;
        healthSlider.fillRect.gameObject.SetActive(true);
        healthSlider.value = currentHealthAmount;

        if(currentHealthAmount >= amountToDestroy)
        {
            gameManager.AddScore(amountToDestroy);
            Destroy(gameObject, 0.1f);
        }
    }
}
