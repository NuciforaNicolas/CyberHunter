using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider, soundSlider;
    [SerializeField] InputField score;
    public static bool volumeChanged = false;

    private void Awake()
    {
        musicSlider.value = SaveGame.GetMusicVolume();
        soundSlider.value = SaveGame.GetSoundVolume();
    }

    private void Update()
    {
        if(volumeChanged){
            Camera.main.GetComponent<AudioSource>().volume = SaveGame.GetMusicVolume();
            volumeChanged = false;
        }
    }

    public void LoadLevel(int i){
        SceneManager.LoadScene(i);
    }


    public void OpenMainMenuCanvas(GameObject mainMenu)
    {
        mainMenu.GetComponent<CanvasGroup>().alpha = 1;
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        mainMenu.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseMainMenuCanvas(GameObject mainMenu)
    {
        mainMenu.GetComponent<CanvasGroup>().alpha = 0;
        mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        mainMenu.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenLevelsCanvas(GameObject levels){
        levels.GetComponent<CanvasGroup>().alpha = 1;
        levels.GetComponent<CanvasGroup>().blocksRaycasts = true;
        levels.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseLevelsCanvas(GameObject levels)
    {
        levels.GetComponent<CanvasGroup>().alpha = 0;
        levels.GetComponent<CanvasGroup>().blocksRaycasts = false;
        levels.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenScoreCanvas(GameObject score)
    {
        score.GetComponent<CanvasGroup>().alpha = 1;
        score.GetComponent<CanvasGroup>().blocksRaycasts = true;
        score.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseScoreCanvas(GameObject score)
    {
        score.GetComponent<CanvasGroup>().alpha = 0;
        score.GetComponent<CanvasGroup>().blocksRaycasts = false;
        score.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenTutorialCanvas(GameObject tutorial)
    {
        tutorial.GetComponent<CanvasGroup>().alpha = 1;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = true;
        tutorial.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseTutorialCanvas(GameObject tutorial)
    {
        tutorial.GetComponent<CanvasGroup>().alpha = 0;
        tutorial.GetComponent<CanvasGroup>().blocksRaycasts = false;
        tutorial.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenOptionsCanvas(GameObject options)
    {
        options.GetComponent<CanvasGroup>().alpha = 1;
        options.GetComponent<CanvasGroup>().blocksRaycasts = true;
        options.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseOptionsCanvas(GameObject options)
    {
        options.GetComponent<CanvasGroup>().alpha = 0;
        options.GetComponent<CanvasGroup>().blocksRaycasts = false;
        options.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenCreditsCanvas(GameObject credits)
    {
        credits.GetComponent<CanvasGroup>().alpha = 1;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = true;
        credits.GetComponent<CanvasGroup>().interactable = true;
    }

    public void CloseCreditsCanvas(GameObject credits)
    {
        credits.GetComponent<CanvasGroup>().alpha = 0;
        credits.GetComponent<CanvasGroup>().blocksRaycasts = false;
        credits.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenPauseCanvas(GameObject pause){
        pause.GetComponent<CanvasGroup>().alpha = 1;
        pause.GetComponent<CanvasGroup>().blocksRaycasts = true;
        pause.GetComponent<CanvasGroup>().interactable = true;
        GameManager.stopGame = true;
    }
    public void ClosePauseCanvas(GameObject pause)
    {
        pause.GetComponent<CanvasGroup>().alpha = 0;
        pause.GetComponent<CanvasGroup>().blocksRaycasts = false;
        pause.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenGameOverCanvas(GameObject gameOver)
    {
        gameOver.GetComponent<CanvasGroup>().alpha = 1;
        gameOver.GetComponent<CanvasGroup>().blocksRaycasts = true;
        gameOver.GetComponent<CanvasGroup>().interactable = true;
    }
    public void CloseGameOverCanvas(GameObject gameOver)
    {
        gameOver.GetComponent<CanvasGroup>().alpha = 0;
        gameOver.GetComponent<CanvasGroup>().blocksRaycasts = false;
        gameOver.GetComponent<CanvasGroup>().interactable = false;
    }

    public void OpenCompleteCanvas(GameObject complete)
    {
        complete.GetComponent<CanvasGroup>().alpha = 1;
        complete.GetComponent<CanvasGroup>().blocksRaycasts = true;
        complete.GetComponent<CanvasGroup>().interactable = true;
        score.text = CoinManager.instance.coins.ToString();
    }
    public void CloseCompleteCanvas(GameObject complete)
    {
        complete.GetComponent<CanvasGroup>().alpha = 0;
        complete.GetComponent<CanvasGroup>().blocksRaycasts = false;
        complete.GetComponent<CanvasGroup>().interactable = false;
    }
    public void OpenInputCanvas(GameObject input)
    {
        input.GetComponent<CanvasGroup>().interactable = true;
        input.GetComponent<CanvasGroup>().blocksRaycasts = true;
        input.GetComponent<CanvasGroup>().alpha = 1;
        GameManager.stopGame = false;
    }

    public void CloseInputCanvas(GameObject input)
    {
        input.GetComponent<CanvasGroup>().interactable = false;
        input.GetComponent<CanvasGroup>().blocksRaycasts = false;
        input.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void SaveMusicVolume(){
        SaveGame.SaveMusicVolume(musicSlider.value);
        volumeChanged = true;
    }

    public void SaveSoundVolume()
    {
        SaveGame.SaveSoundVolume(soundSlider.value);
        volumeChanged = true;
    }

    public void Exit(){
        Application.Quit();
    }
}
