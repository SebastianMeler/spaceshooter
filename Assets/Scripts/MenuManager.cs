using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text HighScore;
    public int HighScorePoints;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (HighScorePoints < GameManager.Instance.Points)
        {
            HighScorePoints = GameManager.Instance.Points;
        }
        HighScore.text = "Points: " + GameManager.Instance.Points;
    }
}
