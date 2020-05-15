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

    private void Start()
    {
        instance = this;
        Time.timeScale = 1;
    }

    public void GameOver(){
        playerPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Complete()
    {
        playerPanel.GetComponent<ButtonHandler>().SetUpState();
        playerPanel.gameObject.SetActive(false);
        completePanel.gameObject.SetActive(true);
    }

    public void RestartGame(){
        SceneManager.LoadScene("level1");
    }
}
