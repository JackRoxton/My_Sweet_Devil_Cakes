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
    public Image PickImage;

    public Image PokedexImage;
    public TMP_Text PokedexText;

    public TMP_Text Instructions;

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

        PokedexCanvas.gameObject.SetActive(false);
    }
    #endregion

    public void Play()
    {
        ShowDex();
        GameManager.Instance.Play();
    }

    public void ShowName(string a, Sprite b)
    {
        PickName.text = a;
        PickImage.sprite = b;
    }

    public void PokedexShowHover(Recipe recipe)
    {
        PokedexImage.sprite = recipe.Sprite;
        PokedexText.text = recipe.name;
    }

    public void RecipePicked()
    {
        ShowFridge();
        Instructions.text = "Liste des Ingrédients :\n- " 
            + GameManager.Instance.pickedRecipe.Ingredients[0].name + "\n- "
            + GameManager.Instance.pickedRecipe.Ingredients[1].name + "\n- "
            + GameManager.Instance.pickedRecipe.Ingredients[2].name;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
