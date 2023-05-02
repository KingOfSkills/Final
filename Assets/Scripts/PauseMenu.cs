using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    public GameObject music;
    public Toggle musicToggle;
    public bool isMusicPlaying;

    private GameManager gameManager;
    private GameScene gameScene;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameScene = FindObjectOfType<GameScene>();
    }
    public void Continue()
    {
        gameManager.Resume();
    }
    public void LoadGame()
    {
        string loadData =  PlayerPrefs.GetString("GameData");

        GameData loadSaveObject = JsonUtility.FromJson<GameData>(loadData);

        var loadName = loadSaveObject.name;
        var loadLives = loadSaveObject.lives;
        var loadTime = loadSaveObject.time;
        var loadScore = loadSaveObject.score;

        gameScene.ReloadGameScene(loadName, loadLives, loadTime, loadScore);
    }
    public void SaveGame()
    {
        GameData gameData = new GameData();
        gameData.name = gameScene.playerName;
        gameData.lives = gameScene.playerLives;
        gameData.score = gameScene.score;
        gameData.time = gameScene.gameTime;

        string json = JsonUtility.ToJson(gameData);
        PlayerPrefs.SetString("GameData", json);
        PlayerPrefs.Save();
    }
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void DisplayJSON()
    {
        string json = PlayerPrefs.GetString("GameData");

        StreamReader reader = new StreamReader(json);
        while (!reader.EndOfStream)
        {
            Debug.Log(reader.ReadLine());
        }
        reader.Close();
    }
    public void ToggleMusic()
    {
        isMusicPlaying = musicToggle.isOn;
        if (isMusicPlaying)
        {
            music.SetActive(true);
        }
        else
        {
            music.SetActive(false);
        }
    }
    public class GameData
    {
        public string name;
        public int lives;
        public int score;
        public float time;
    }
}
