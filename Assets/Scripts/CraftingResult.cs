using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingResult : MonoBehaviour
{
    public List<CraftingSlot> craft = new List<CraftingSlot>();

    public List<DragnDrop> StartCraft()
    {
        List<DragnDrop> list = new List<DragnDrop>();
        foreach (CraftingSlot item in craft)
        {
            list.Add(item.Ingredient);
        }
        return list;
    }

    public bool CraftCheck()
    {
        List<Ingredient> list = new List<Ingredient>();
        foreach (CraftingSlot item in craft)
        {
            if (item.Ingredient == null) return false;
        }
        return true;
    }

    public void Clear()
    {
        foreach (CraftingSlot item in craft)
        {
            item.Clear();
        }
    }

}
