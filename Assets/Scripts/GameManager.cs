using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    public TextMeshProUGUI timeText;
    public float timeStart;
    bool timerActive = true;
    public float seconds, minutes, milliseconds, hours;
    private float stopTime;

    public TextMeshProUGUI livesText;

    public TextMeshProUGUI highScoreText;

    public bool isGameActive;

    public Button restartButton;

    public List<GameObject> enemies;
    private float spawnRate = 2.0f;


    //Lives
    private int lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnEnemy());
        score = 0;
        UpdateScore(0);
        timeText.text = timeStart.ToString("F2");
        lives = 3;
        AddLives(0);
        UpdateHighScoreText();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            hours = (int)(Time.timeSinceLevelLoad / 3600f);


            milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;

            minutes = (int)(Time.timeSinceLevelLoad / 60f) % 60;

            seconds = (int)(Time.time % 60f);

            timeText.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
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
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

public class SaveTime : MonoBehaviour
{
    public Text Time;
    string _currentTime;
    public void SetTime()
    {
        _currentTime = Time.text;
        PlayerPrefs.SetString("Time", _currentTime);
        Debug.Log("Your Time Is" + PlayerPrefs.GetString("Time"));
    }
}
