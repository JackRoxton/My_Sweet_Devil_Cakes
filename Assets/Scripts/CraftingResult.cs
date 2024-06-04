using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingResult : MonoBehaviour
{
    public List<CraftingSlot> craft = new List<CraftingSlot>();

    public void StartCraft()
    {
        List<Ingredient> list = new List<Ingredient>();
        foreach (CraftingSlot item in craft)
        {
            list.Add(item.Ingredient.ingredient);
        }

    }
}
