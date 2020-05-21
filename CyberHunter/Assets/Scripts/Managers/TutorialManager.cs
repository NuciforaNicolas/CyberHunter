using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] Canvas controls, extra, ui;

    private void Start()
    {
        controls.gameObject.SetActive(false);
        extra.gameObject.SetActive(false);
        ui.gameObject.SetActive(false);
    }

    public void Next(int i){
        switch(i){
            case 0:
                controls.gameObject.SetActive(false);
                ui.gameObject.SetActive(true);
                break;
            case 1:
                ui.gameObject.SetActive(false);
                extra.gameObject.SetActive(true);
                break;
        }
    }

    public void Prev(int i)
    {
        switch (i)
        {
            case 1:
                ui.gameObject.SetActive(false);
                controls.gameObject.SetActive(true);
                break;
            case 2:
                extra.gameObject.SetActive(false);
                ui.gameObject.SetActive(true);
                break;
        }
    }
}
