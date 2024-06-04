using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickRecipe : MonoBehaviour
{
    public PickButton first, second, third, fourth;

    public void Pick()
    {
        List<Recipe> list = RecipeManager.Instance.GetRecipes();
        first.Gimme(list[0]);
        if (list.Count > 1)
            second.Gimme(list[1]);
        if (list.Count > 2)
            third.Gimme(list[2]);
        if (list.Count > 3)
            fourth.Gimme(list[3]);
    }
}
