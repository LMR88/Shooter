using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject scoreText;
    public int score = 0;
    public int scoreToNextLevel = 1000;
    public int scoreToBoss = 3000;
    public GameObject winText;

    public bool isLastLevel = false;
    
    private bool bossAlreadySpawned = false;

    private float BossApparition = 4f;

    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.GetComponent<TMP_Text>().text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.R) && isAlive == false)
        {
            SceneManager.LoadScene(0);
        }
        else if (Input.GetKeyDown(KeyCode.K) && isAlive)
        {
            SceneManager.LoadScene(0);
        }

        if (score > scoreToNextLevel && isLastLevel == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (score > scoreToBoss && isLastLevel == true && bossAlreadySpawned == false)
        {
            BossManager.instance.startBossSpawn();
            bossAlreadySpawned = true;
        }

        new WaitForSeconds(BossApparition);
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverText.SetActive(true);
    }

    public void Win()
    {
        isAlive = true;
        winText.SetActive(true);
    }

    public void UpdateScore(int points)
    {
        score = score + points;
        scoreText.GetComponent<TMP_Text>().text = "Score: " + score;
    }
}
