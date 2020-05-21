using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Canvas mainMenu, levels, options, score, credits, tutorial;

    public void LoadLevel(int i){
        SceneManager.LoadScene(i);
    }

    public void LoadMainManuCanvas(int prevCanv){
        switch(prevCanv){
            case 1: // previous canvas = Levels
                levels.gameObject.SetActive(false);
                break;
            case 2: // previous canvas = Score
                score.gameObject.SetActive(false);
                break;
            case 3: // previous canvas = Tutorial
                tutorial.gameObject.SetActive(false);
                break;
            case 4: // previous canvas = Options
                options.gameObject.SetActive(false);
                break;
            case 5: // previous canvas = Credits
                credits.gameObject.SetActive(false);
                break;
        }
        mainMenu.gameObject.SetActive(true);
    }

    public void LoadLevelsCanvas(){
        mainMenu.gameObject.SetActive(false);
        levels.gameObject.SetActive(true);
    }

    public void LoadOptionsCanvas(){
        
    }

    public void LoadScoreCanvas(){
        
    }

    public void LoadTutorialCanvas()
    {
        mainMenu.gameObject.SetActive(false);
        tutorial.gameObject.SetActive(true);
    }

    public void LoadCreditsCanvas(){
        mainMenu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void Exit(){
        Application.Quit();
    }
}
