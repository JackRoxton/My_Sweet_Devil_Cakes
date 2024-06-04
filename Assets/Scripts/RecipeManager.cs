using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : Singleton<RecipeManager>
{
    public List<Recipe> recipes;
    List<Recipe> undoneRecipes;
    public List<Ingredient> ingredients;
    //ingrédients consommés

    private void Start()
    {
        undoneRecipes = recipes;
    }

    public Recipe CheckRecipe(Ingredient i1,Ingredient i2, Ingredient i3)
    {
        foreach (var recipe in recipes)
        {
            if(recipe.Ingredients.Contains(i1) && recipe.Ingredients.Contains(i2) && recipe.Ingredients.Contains(i3))
            {
                return recipe;
            }
        }
        return null;
    }

    public int RecipeQuality(Ingredient i1, Ingredient i2, Ingredient i3, Recipe chosenRecipe)
    {
        int i = 0;
        List<Ingredient> list = new List<Ingredient>();
        list.Add(i1);
        list.Add(i2);
        list.Add(i3);
        foreach (Ingredient ingredient in chosenRecipe.Ingredients)
        {
            if (list.Contains(ingredient))
            {
                i++;
            }
        }
        return i;
    }

    public List<Ingredient> GetIngredients(Recipe recipe)
    {
        return recipe.Ingredients;
    }

    public void RecipeDone(Recipe recipe)
    {
        undoneRecipes.Remove(recipe);
    }

    /*public List<Recipe> GetUndoneRecipes()
    {
        int i = 4;
        switch (undoneRecipes.Count)
        {
            case > 2:
                i = 3;
                break;
            case 2:
                i = 2;
                break;
            case 1:
                i = 1;
                break;
            case 0: 
                Debug.Log("100%");
                i = 3;
                break;
        }
        List<Recipe> list = new List<Recipe>();
        do
        {
            int x = Random.Range(0, undoneRecipes.Count);
            if (!list.Contains(undoneRecipes[x]))
            {
                list.Add(undoneRecipes[x]);
                i--;
            }
        } while (i != 0);

        list.Add(GameManager.Instance.pickedRecipe);
        return list;
    }*/

    public List<Recipe> GetRecipes()
    {
        int i = 3;
        List<Recipe> list = new List<Recipe>();
        do
        {
            int x = Random.Range(0, undoneRecipes.Count);
            if (!list.Contains(undoneRecipes[x]))
            {
                list.Add(undoneRecipes[x]);
                i--;
            }
        } while (i != 0);

        list.Add(GameManager.Instance.pickedRecipe);
        return list;
    }

    public bool MatchingRecipe(Recipe recipe)
    {
        foreach(var rec in recipes)
        {
            if (rec == recipe)
                return true;
        }
        return false;
    }
}
