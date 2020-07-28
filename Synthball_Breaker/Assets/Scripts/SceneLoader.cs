using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;

    GameSession gameStatus;

    // Start is called before the first frame update
    void Start()
    {        
        gameStatus = FindObjectOfType<GameSession>();
    }

    public void LoadFirstScene()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(0);
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
