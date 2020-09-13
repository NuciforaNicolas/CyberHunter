using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject menuManager, complete, gameover, input;
    public static bool stopGame;

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
        menuManager.GetComponent<MenuManager>().OpenGameOverCanvas(gameover);
        menuManager.GetComponent<MenuManager>().CloseInputCanvas(input);
        stopGame = true;
    }

    public void Complete()
    {
        CoinManager.instance.SaveCoins();
        menuManager.GetComponent<MenuManager>().OpenCompleteCanvas(complete);
        menuManager.GetComponent<MenuManager>().CloseInputCanvas(input);
        stopGame = true;
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu(){
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int level){
        SceneManager.LoadScene(level);
    }
}
