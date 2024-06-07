using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class CodexManager : Singleton<CodexManager>
{
    List<Recipe> recipes = new List<Recipe>();
    public List<CodexButton> buttons = new List<CodexButton>();
    private void Start()
    {
        recipes = RecipeManager.Instance.recipes;
    }

    public void CheckList(Recipe recipe, int quality, Sprite stars)
    {
        foreach(CodexButton b in buttons)
        {
            if(recipe == b.recipe)
            {
                if (quality <= b.quality) return;
                b.image.GetComponent<Image>().color = Color.white;
                b.quality = quality;
                b.stars.sprite = stars;
                return;
            }
        }
        return;
    }

    public bool FullCheck()
    {
        foreach (CodexButton b in buttons)
        {
            if (b.quality != 3)
            {
                return false;
            }
        }
        return true;
    }
}
