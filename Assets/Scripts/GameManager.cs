using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PickRecipe picker;
    public Recipe pickedRecipe;
    public Bowl bowl;
    List<Ingredient> bowlIngredients;
    public Fridge fridge;

    public enum GameStates
    {
        MainMenu,
        Pokedex,
        PokedexPick,
        FridgePick,
        Evaluation
    }
    public GameStates CurrentState = GameStates.MainMenu;

    public void Play()
    {
        CurrentState = GameStates.Pokedex;
    }

    public void SetPickedRecipe(Recipe recipe)
    {
        pickedRecipe = recipe;
        CurrentState = GameStates.FridgePick;
        fridge.Spawn();
        UIManager.Instance.RecipePicked();
    }

    public void IngredientsCheck()
    {
        if (bowl.ingredients.Count != 3) return;
        bowlIngredients = bowl.ingredients;
        fridge.Clear();
        CurrentState = GameStates.PokedexPick;
        UIManager.Instance.IngredientsOk();
        picker.Pick();
    }

    public void GrannyPick(Recipe recipe)
    {
        int i = RecipeManager.Instance.RecipeQuality(bowlIngredients[0], bowlIngredients[1], bowlIngredients[2], recipe);
        UIManager.Instance.Evaluation(recipe, i);
    }

    public void Replay()
    {
        CurrentState = GameStates.MainMenu;
        bowl.Clear();
    }
}
