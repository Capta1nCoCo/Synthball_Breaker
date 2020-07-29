using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 20;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] int currentScore = 0;

    

    private void Awake()
    {        
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
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

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoplayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void IncreaseGameSpeed(float amount)
    {
        gameSpeed += amount;
    }

    public void DecreaseGameSpeed(float amount)
    {
        gameSpeed -= amount;
    }

}
