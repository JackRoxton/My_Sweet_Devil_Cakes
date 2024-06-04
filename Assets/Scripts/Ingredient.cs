using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ingredients", order = 1)]
public class Ingredient : ScriptableObject 
{
    public Sprite Sprite;
    public Sprite badSprite;
    public string IngredientName;

}

