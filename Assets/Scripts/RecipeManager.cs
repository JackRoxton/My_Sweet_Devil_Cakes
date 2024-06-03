using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : Singleton<RecipeManager>
{
    public List<Recipe> recipes;

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

    /*public bool CheckCorrectRecipe(Ingredient i1, Ingredient i2)
    {
        foreach (var recipe in recipes)
        {
            if (recipe.Ingredients.Contains(i1) && recipe.Ingredients.Contains(i2))
            {
                return true;
            }
        }
        return false;
    }*/

    public List<Ingredient> GetIngredients(Recipe recipe)
    {
        return recipe.Ingredients;
    }
}
