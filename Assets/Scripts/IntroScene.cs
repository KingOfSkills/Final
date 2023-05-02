using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public InputField playerNameInputField;
    public Slider gameTimeSlider;
    public Dropdown playerLivesDropdown;

    public Text timeText;
    public Text instructionText;

    private void Start()
    {
        if (GameManager.playerName != null)
        {
            playerNameInputField.text = GameManager.playerName;
        }
        if (GameManager.gameStartTime != 0)
        {
            gameTimeSlider.value = GameManager.gameStartTime;
        }
        else
        {
            GameManager.gameStartTime = 60;
        }
    }
    public void SetPlayerName()
    {
        GameManager.playerName = playerNameInputField.text;
    }
    public void SetGameTime()
    {
        GameManager.gameStartTime = gameTimeSlider.value;
        timeText.text = gameTimeSlider.value.ToString();
    }
    public void SetPlayerLives()
    {
        GameManager.playerLives = playerLivesDropdown.value;
    }
    public void Next()
    {
        if (playerLivesDropdown.value > 0 && playerNameInputField.text != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            instructionText.text = "You have NOT completed the intro!\nCheck your name and/or lives.";
        }
    }
}
