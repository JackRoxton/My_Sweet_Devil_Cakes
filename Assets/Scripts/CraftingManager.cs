using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : Singleton<CraftingManager>
{
    public List<Transform> craftSpots;
    public DragnDrop prefab;

    public void InstantiateCraft(List<Ingredient> list)
    {
        int i = 0;
        foreach (Ingredient x in list) 
        {
            DragnDrop go = Instantiate(prefab, craftSpots[i].position, Quaternion.identity);
            go.ingredient = x;
            i++;
        }
    }
}
