using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const float LeftSize = -5f;
    public const float RightSize = 5f;

    public int Points;
    public int Lives = 5;

    public static GameManager Instance;
    public int HighScorePoints;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
    }

    public void ScorePoints()
    {
        Points++;
    }

    private void Update()
    {
        if (HighScorePoints < GameManager.Instance.Points)
        {
            HighScorePoints = GameManager.Instance.Points;
        }
    }
}
