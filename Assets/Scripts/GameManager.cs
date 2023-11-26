using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using System.Threading;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI timeText;
    public float timeStart;
    public Timer timerToStop;
    private float stopTime;

    public TextMeshProUGUI livesText;

    public bool isGameActive;

    public Button restartButton;

    public List<GameObject> enemies;
    private float spawnRate = 1.0f;

    //Lives
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemy());
        score = 0;
        UpdateScore(0);
        timeText.text += timeStart.ToString("F2");
        lives = 3;
        AddLives(0);
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStart += Time.deltaTime;
        timeText.text = timeStart.ToString("F2");
    }

    public void AddLives(int value)
    {
        lives += value;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            GameOver();
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, enemies.Count);
            Instantiate(enemies[index]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void TimerStart()
    {

    }
    public void TimerStop()
    {
        isGameActive=false;
        timeStart = Time.time;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
