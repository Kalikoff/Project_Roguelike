using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuEvents : MonoBehaviour
{
    public GameObject MenuButtons;
    public GameObject PlayerRecords;
    public GameObject WantToExit;
    public TextMeshProUGUI HighScoreText;

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowRecords()
    {
        MenuButtons.SetActive(false);
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        PlayerRecords.SetActive(true);
    }

    public void BackToMainMenu()
    {
        MenuButtons.SetActive(true);
        PlayerRecords.SetActive(false);
    }

    public void ExitGame()
    {
        MenuButtons.SetActive(false);
        WantToExit.SetActive(true);
    }

    public void ExitGame_Yes()
    {
        Application.Quit();
    }

    public void ExitGame_No()
    {
        MenuButtons.SetActive(true);
        WantToExit.SetActive(false);
    }
}