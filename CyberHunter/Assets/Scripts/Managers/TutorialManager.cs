using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    
    public void openControlsTutorial(GameObject controls){
        controls.GetComponent<CanvasGroup>().alpha = 1;
        controls.GetComponent<CanvasGroup>().blocksRaycasts = true;
        controls.GetComponent<CanvasGroup>().interactable = true;
    }

    public void closeControlsTutorial(GameObject controls)
    {
        controls.GetComponent<CanvasGroup>().alpha = 0;
        controls.GetComponent<CanvasGroup>().blocksRaycasts = false;
        controls.GetComponent<CanvasGroup>().interactable = false;
    }

    public void openUiTutorial(GameObject ui)
    {
        ui.GetComponent<CanvasGroup>().alpha = 1;
        ui.GetComponent<CanvasGroup>().blocksRaycasts = true;
        ui.GetComponent<CanvasGroup>().interactable = true;
    }

    public void closeUiTutorial(GameObject ui)
    {
        ui.GetComponent<CanvasGroup>().alpha = 0;
        ui.GetComponent<CanvasGroup>().blocksRaycasts = false;
        ui.GetComponent<CanvasGroup>().interactable = false;
    }

    public void openExtrasTutorial(GameObject extras)
    {
        extras.GetComponent<CanvasGroup>().alpha = 1;
        extras.GetComponent<CanvasGroup>().blocksRaycasts = true;
        extras.GetComponent<CanvasGroup>().interactable = true;
    }

    public void closeExtrasTutorial(GameObject extras)
    {
        extras.GetComponent<CanvasGroup>().alpha = 0;
        extras.GetComponent<CanvasGroup>().blocksRaycasts = false;
        extras.GetComponent<CanvasGroup>().interactable = false;
    }


}
