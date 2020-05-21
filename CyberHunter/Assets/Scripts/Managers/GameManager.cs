using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Canvas playerPanel, gameOverPanel, completePanel, optionPanel;
    bool stopGame;
    private void Start()
    {
        instance = this;
        stopGame = false;
    }

    private void Update()
    {
        if (stopGame)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void GameOver(){
        //playerPanel.gameObject.SetActive(false);
        disableInputGui();
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Complete()
    {
        //playerPanel.gameObject.SetActive(false);
        disableInputGui();
        completePanel.gameObject.SetActive(true);
    }

    public void OpenOptionMenu(){
        disableInputGui();
        optionPanel.gameObject.SetActive(true);
        stopGame = true;
    }

    public void CloseOptionMenu(){
        optionPanel.gameObject.SetActive(false);
        enableInputGui();
        stopGame = false;
    }

    void disableInputGui(){
        playerPanel.GetComponent<CanvasGroup>().interactable = false;
        playerPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        playerPanel.GetComponent<CanvasGroup>().alpha = 0;
    }

    void enableInputGui(){
        playerPanel.GetComponent<CanvasGroup>().interactable = true;
        playerPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        playerPanel.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }
}
