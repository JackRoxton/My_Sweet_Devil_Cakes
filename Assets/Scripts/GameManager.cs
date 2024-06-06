using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public PickRecipe picker;
    public Recipe pickedRecipe;
    public Bowl bowl;
    List<DragnDrop> bowlIngredients;
    public Fridge fridge;
    

    public enum GameStates
    {
        MainMenu,
        Pokedex,
        PokedexPick,
        FridgePick,
        Crafting,
        Evaluation
    }
    public GameStates CurrentState = GameStates.MainMenu;

    public void Play()
    {
        SoundManager.Instance.Play("Clic");
        CurrentState = GameStates.Pokedex;
        SoundManager.Instance.StopMusic("1");
        SoundManager.Instance.PlayMusic("2");
    }

    public void SetPickedRecipe(Recipe recipe)
    {
        SoundManager.Instance.Play("Clic");
        pickedRecipe = recipe;
        CurrentState = GameStates.FridgePick;
        fridge.Spawn();
        UIManager.Instance.RecipePicked();
    }

    public void IngredientsCheck()
    {
        if (bowl.ingredients.Count < 3) return;
        bowl.Empty();
        bowlIngredients = bowl.ingredients;
        fridge.Empty();
        CurrentState = GameStates.PokedexPick;
        UIManager.Instance.IngredientsOk();
        picker.Pick();
    }

    public void Craft()
    {
        CurrentState = GameStates.Crafting;
        SoundManager.Instance.Play("Clic");
        CraftingManager.Instance.InstantiateCraft(bowlIngredients);
    }

    public void SetFinalIngredients(List<DragnDrop> list)
    {
        bowlIngredients.Clear();
        bowlIngredients.Add(list[0]);
        bowlIngredients.Add(list[1]);
        bowlIngredients.Add(list[2]);
        GrannyPick(pickedRecipe);
    }

    public void GrannyPick(Recipe recipe)
    {
        // pickedRecipe = recipe;
        int i = RecipeManager.Instance.RecipeQuality(bowlIngredients[0], bowlIngredients[1], bowlIngredients[2], recipe);
        UIManager.Instance.Evaluation(recipe, i);
    }

    public void Replay()
    {
        //if 100%, 100% screen instead
        SoundManager.Instance.StopMusic("2");
        SoundManager.Instance.PlayMusic("1");
        CurrentState = GameStates.MainMenu;
        fridge.Clear();
        bowl.Clear();
    }
}
