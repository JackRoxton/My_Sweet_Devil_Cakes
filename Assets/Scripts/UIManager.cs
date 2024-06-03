using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject MainMenuCanvas;
    public GameObject PokedexCanvas;

    public GameObject FridgeDragCanvas;
    public GameObject FridgeDrag;

    public GameObject PickCanvas;
    public GameObject Pick;

    public TMP_Text PickName;

    #region
    public void ShowMain()
    {
        MainMenuCanvas.gameObject.SetActive(true);

        PokedexCanvas.gameObject.SetActive(false);
    }

    public void ShowDex()
    {
        PokedexCanvas.gameObject.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowPick() 
    {
        PickCanvas.gameObject.SetActive(true);
        Pick.gameObject.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowFridge()
    {
        FridgeDragCanvas.gameObject.SetActive(true);
        FridgeDrag.gameObject.SetActive(true);

        PickCanvas.gameObject.SetActive(false);
        Pick.gameObject.SetActive(false);
    }
    #endregion

    public void Play()
    {
        ShowPick();
        GameManager.Instance.Play();
    }

    public void ShowName(string a)
    {
        PickName.text = a;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
