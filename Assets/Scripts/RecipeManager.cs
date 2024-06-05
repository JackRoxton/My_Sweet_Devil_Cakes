using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : Singleton<RecipeManager>
{
    public List<Recipe> recipes;
    //List<Recipe> undoneRecipes;
    public List<DragnDrop> ingredients = new List<DragnDrop>();
    public GameObject dragndrop;
    public List<Ingredient> ingredientsetup;

    private void Start()
    {
        int i = 0;
        foreach(Ingredient ingredient in ingredientsetup)
        {
            GameObject g = Instantiate(dragndrop,new Vector2(20,20),Quaternion.identity);
            g.GetComponent<DragnDrop>().ingredient = ingredientsetup[i];
            ingredients[i] = g.GetComponent<DragnDrop>();
            i++;
        }
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

    public int RecipeQuality(DragnDrop i1, DragnDrop i2, DragnDrop i3, Recipe chosenRecipe)
    {
        int i = 0;
        List<Ingredient> list = new List<Ingredient>();
        if(!i1.bad)
            list.Add(i1.ingredient);
        if (!i2.bad)
            list.Add(i2.ingredient);
        if (!i3.bad)
            list.Add(i3.ingredient);
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

    /*public void RecipeDone(Recipe recipe)
    {
        undoneRecipes.Remove(recipe);
    }*/

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
            int x = Random.Range(0, recipes.Count);
            if (!list.Contains(recipes[x]))
            {
                list.Add(recipes[x]);
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
