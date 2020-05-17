using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Canvas playerPanel;
    [SerializeField] Canvas gameOverPanel;
    [SerializeField] Canvas completePanel;
    public bool gameOver;
    private void Start()
    {
        instance = this;
        gameOver = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (gameOver)
            Time.timeScale = 0;
    }

    public void GameOver(){
        playerPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        gameOver = true;
    }

    public void Complete()
    {
        playerPanel.gameObject.SetActive(false);
        completePanel.gameObject.SetActive(true);
        gameOver = true;
    }

    public void RestartGame(){
        SceneManager.LoadScene("level1");
    }
}
