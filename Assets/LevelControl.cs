using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelControl : MonoBehaviour
{
    public GameObject LevelCompleteImage;
    public GameObject GameOverImage;
    public TextMeshProUGUI YourScore;

    [HideInInspector] static public int levelsCompleted = 0;
    [HideInInspector] static public int roomsCompleted = 0;
    private bool isLevelCompleted = false;

    private void Update()
    {
        if (roomsCompleted >= 5)
        {
            levelsCompleted++;
            roomsCompleted = 0;

            isLevelCompleted = true;
        }

        if (isLevelCompleted)
        {
            ShowCompleteLevel();
            isLevelCompleted = false;
        }

        if (PlayerController.health <= 0)
        {
            levelsCompleted = 0;
            roomsCompleted = 0;

            ShowGameOver();
        }
    }

    private void ShowCompleteLevel()
    {
        LevelCompleteImage.SetActive(true);
    }

    private void ShowGameOver()
    {
        YourScore.text = "YOUR SCORE: " + PlayerInfo.score;
        GameOverImage.SetActive(true);
    }
}
