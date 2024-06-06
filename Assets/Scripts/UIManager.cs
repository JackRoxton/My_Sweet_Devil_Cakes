using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject MainMenuCanvas;
    public GameObject Menu;

    public GameObject CreditsCanvas;
    public GameObject PokedexCanvas;

    public GameObject FridgeDragCanvas;
    public GameObject FridgeDrag;

    public GameObject PickCanvas;
    public GameObject Pick;

    public GameObject Crafting;
    public GameObject CraftingCanvas;

    public GameObject EvaluationCanvas;

    public TMP_Text PickName;
    public Image PickImage;

    public Image PokedexImage;
    public TMP_Text PokedexText;

    public TMP_Text Instructions;

    public Image EvaluationImage;
    public List<Sprite> EvaluationSprites;
    public Image RecipeResult;
    public TMP_Text EvaluationText;

    public Granny Granny;

    #region
    public void ShowMain()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        Menu.gameObject.SetActive(true);

        EvaluationCanvas.gameObject.SetActive(false);

        GameManager.Instance.Replay();
    }

    public void ShowDex()
    {
        PokedexCanvas.gameObject.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
        Menu.gameObject .SetActive(false);
    }

    public void ShowPick() 
    {
        PickCanvas.gameObject.SetActive(true);
        Pick.gameObject.SetActive(true);

        FridgeDragCanvas.gameObject.SetActive(false);
        FridgeDrag.gameObject.SetActive(false);
    }

    public void ShowFridge()
    {
        FridgeDragCanvas.gameObject.SetActive(true);
        FridgeDrag.gameObject.SetActive(true);

        PokedexCanvas.gameObject.SetActive(false);
    }

    public void ShowCraft()
    {
        Crafting.gameObject.SetActive(true);
        CraftingCanvas.gameObject.SetActive(true);

        PickCanvas.gameObject.SetActive(false);
        Pick.gameObject.SetActive(false);
    }

    public void ShowEvaluation()
    {
        EvaluationCanvas.gameObject.SetActive(true);

        Crafting.gameObject.SetActive(false);
        CraftingCanvas.gameObject.SetActive(false);
    }
    #endregion

    public void Play()
    {
        ShowDex();
        GameManager.Instance.Play();
    }

    public void Credits()
    {
        SoundManager.Instance.Play("Clic");
        CreditsCanvas.gameObject.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SoundManager.Instance.Play("Clic");
        MainMenuCanvas.gameObject.SetActive(true);

        CreditsCanvas.gameObject.SetActive(false);
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
        Instructions.text = "Liste des Ingredients :\n- " 
            + GameManager.Instance.pickedRecipe.Ingredients[0].name + "\n- "
            + GameManager.Instance.pickedRecipe.Ingredients[1].name + "\n- "
            + GameManager.Instance.pickedRecipe.Ingredients[2].name;
    }

    public void IngredientsPicked()
    {
        GameManager.Instance.IngredientsCheck();
        SoundManager.Instance.Play("Clic");
    }

    public void IngredientsOk()
    {
        ShowPick();
    }

    public void CraftingGrid(Recipe recipe)
    {
        ShowCraft();
        GameManager.Instance.Craft(recipe);
    }

    public void Evaluation(Recipe recipe, int quality)
    {
        ShowEvaluation();
        if(GameManager.Instance.pickedRecipe != GameManager.Instance.grannyRecipe)
        {
            EvaluationText.text = "Vous ne m'avez pas donne la bonne recette !\n";
            Granny.Angry();
            return;
        }
        EvaluationImage.sprite = EvaluationSprites[quality];
        if (quality == 3)
        {
            RecipeResult.sprite = recipe.Sprite;
            EvaluationText.text = recipe.GoodRecipe;
            Granny.Happy();
            SoundManager.Instance.Play("GameWon");
        }
        else
        {
            SoundManager.Instance.Play("GameOver");
            RecipeResult.sprite = recipe.badSprite;
            EvaluationText.text = recipe.BadRecipe;
            Granny.Angry();
        }
        CodexManager.Instance.CheckList(recipe, quality, EvaluationSprites[quality]);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
