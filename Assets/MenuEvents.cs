using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public GameObject LevelCompleteImage;
    public GameObject GameOverImage;

    public void ClickNextLevel()
    {
        LevelCompleteImage.SetActive(false);
        PlayerInfo.score += 100;
        CheckHighScore();

        UpdateScriptsValues();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClickRestartGame()
    {
        GameOverImage.SetActive(false);
        CheckHighScore();
        PlayerInfo.score = 0;

        UpdateScriptsValues();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ClickMainMenu()
    {
        GameOverImage.SetActive(false);
        CheckHighScore();
        PlayerInfo.score = 0;

        UpdateScriptsValues();

        SceneManager.LoadScene(0);
    }

    private void UpdateScriptsValues()
    {
        PlayerController.health = 100;
        RoomSpawner.count = 0;
        RoomSpawner.maxOneWayRooms = 0;
        RoomSpawner.maxTwoWayRooms = 5;
        RoomSpawner.maxThreeWayRooms = 2;
        RoomSpawner.maxFourWayRooms = 0;
        RoomSpawner.isMaxOneWayRooms = true;
        RoomSpawner.isMaxTwoWayRooms = false;
        RoomSpawner.isMaxThreeWayRooms = false;
        RoomSpawner.isMaxFourWayRooms = false;
    }

    private void CheckHighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < PlayerInfo.score)
        {
            PlayerPrefs.SetInt("HighScore", PlayerInfo.score);
        }
    }
}
