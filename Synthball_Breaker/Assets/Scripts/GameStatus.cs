using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 20;
    

    [SerializeField] int currentScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {        
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
        DisplayCurrentScore();
    }
    
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    
    private void DisplayCurrentScore()
    {        
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        DisplayCurrentScore();
    }
}
