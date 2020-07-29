using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] int currentScore = 0;

    float defaultGameSpeed = 1f;    

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
        Time.timeScale = defaultGameSpeed;
    }
    
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    
    private void DisplayCurrentScore()
    {        
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore(int pointsPerBlockDestroyed)
    {
        currentScore += pointsPerBlockDestroyed;
        GetComponentInChildren<Spawner>().MonitorScore(pointsPerBlockDestroyed);
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
