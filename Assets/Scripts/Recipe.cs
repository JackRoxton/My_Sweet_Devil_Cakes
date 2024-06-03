using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Recipes", order = 1)]
public class Recipe : ScriptableObject
{
    public Sprite Sprite;
    public List<Ingredient> Ingredients;
    public string RecipeName;
}

//https://youtu.be/E91NYvDqsy8?si=v1XoGKudB_HihQ2I
