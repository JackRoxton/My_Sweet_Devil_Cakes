using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : Singleton<RecipeManager>
{
    public List<Recipe> recipes;
    List<Recipe> undoneRecipes;
    //public List<Ingredient> ingredients;

    private void Start()
    {
        undoneRecipes = recipes;
    }

    public Recipe CheckRecipe(Ingredient i1,Ingredient i2)
    {
        foreach (var recipe in recipes)
        {
            if(recipe.Ingredients.Contains(i1) && recipe.Ingredients.Contains(i2))
            {
                return recipe;
            }
        }
        return null;
    }

    public List<Ingredient> GetIngredients(Recipe recipe)
    {
        return recipe.Ingredients;
    }

    public void RecipeDone(Recipe recipe)
    {
        undoneRecipes.Remove(recipe);
    }

    public List<Recipe> GetUndoneRecipes()
    {
        int i = 4;
        switch (undoneRecipes.Count)
        {
            case > 3:
                i = 4;
                break;
            case 3:
                i = 3;
                break;
            case 2:
                i = 2;
                break;
            case 1:
                i = 1;
                break;
            case 0: 
                throw new System.Exception("100%");
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

        return list;
    }

    
}
