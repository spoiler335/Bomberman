using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject finishPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField] Text enemyCountText;

    private bool isPaused;
    void Start()
    {
        LevelManager.Instance.isPlayerDead = false;
        gameOverPanel.SetActive(false);
        finishPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        isPaused=false;
    }

    
    void Update()
    {
        enemyCountText.text = "Enemy Count : " + LevelManager.Instance.enemyCount;

        if(LevelManager.Instance.isPlayerDead)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if(LevelManager.Instance.enemyCount == 0)
        {
            Time.timeScale = 0;
            finishPanel.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Escape) )
        {
            if(isPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenuPanel.SetActive(false);
        isPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0;
        pauseMenuPanel.SetActive(true);
        isPaused = true;
    }
    
    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
}
