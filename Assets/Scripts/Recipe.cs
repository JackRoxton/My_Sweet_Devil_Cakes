using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Recipes", order = 1)]
public class Recipe : ScriptableObject
{
    public Sprite Sprite;
    public Sprite badSprite;
    public List<Ingredient> Ingredients;
    public string RecipeName;

    public string GoodRecipe;
    public string BadRecipe;
}
