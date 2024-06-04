using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : Singleton<CraftingManager>
{
    public List<Transform> craftSpots;
    public GameObject prefab;

    public void InstantiateCraft(List<Ingredient> list)
    {
        int i = 0;
        foreach (Ingredient x in list) 
        {
            GameObject go = Instantiate(prefab, craftSpots[i].position, Quaternion.identity);
            go.GetComponent<DragnDrop>().ingredient = x;
            i++;
        }
    }
}
