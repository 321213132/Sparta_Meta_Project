using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager instance;

    private int currentScore = 0;

    private void Awake()
    {
        instance = this;

        if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player.speed = SceneManager.GetActiveScene().name != "AvoidGame" ? 5f : 10f;
    }

    public void GameOver()
    {

    }

    public void RestratGame()
    {

    }

    public void AddScore(int score)
    {
        currentScore = score;
        Debug.Log($"Score : {currentScore}");
    }
}
