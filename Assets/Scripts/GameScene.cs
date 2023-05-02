using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    public Text playerNameText;
    public Text playerLivesText;
    public Text gameTimeText;
    public Text scoreText;

    public string playerName;
    public int playerLives;
    public float gameTime;
    public int score;

    private WriteScores writeScores;
    private void Start()
    {
        // Get References
        playerName = GameManager.playerName;
        playerLives = GameManager.playerLives;
        gameTime = GameManager.gameStartTime;
        score = 0;
        writeScores = FindObjectOfType<WriteScores>();
        // Set UI
        playerNameText.text = playerName;
        playerLivesText.text = playerLives.ToString();
        gameTimeText.text = gameTime.ToString();
        scoreText.text = score.ToString();
    }
    private void Update()
    {
        // Constantly minus time
        gameTime -= Time.deltaTime;
        // Update gameTimeText
        gameTimeText.text = gameTime.ToString("F2"); // "F2" to only have 2 decimals
        if (gameTime <= 0)
        {
            DonePlaying();
        }
    }
    // Need functions for each button
    public void DecreasePoints()
    {
        score -= 100;
        scoreText.text = score.ToString();
    }
    public void IncreasePoints()
    {
        score += 100;
        scoreText.text = score.ToString();
    }
    public void DecreaseLives()
    {
        playerLives -= 1;
        playerLivesText.text = playerLives.ToString();
        if (playerLives <= 0)
        {
            DonePlaying();
        }
    }
    public void IncreaseLives()
    {
        playerLives += 1;
        playerLivesText.text = playerLives.ToString();
    }
    public void DonePlaying()
    {
        writeScores.AddNewScore(playerName, score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ReloadGameScene(string loadName, int loadLives, float loadTime, int loadScore)
    {
        playerName = GameManager.playerName = loadName;
        playerLives = GameManager.playerLives = loadLives;
        gameTime = loadTime;
        score = loadScore;
        // Set UI to match loaded game data
        playerNameText.text = playerName;
        playerLivesText.text = playerLives.ToString();
        gameTimeText.text = gameTime.ToString();
        scoreText.text = score.ToString();
    }
}
