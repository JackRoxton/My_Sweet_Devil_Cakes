using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickButton : MonoBehaviour
{
    public Recipe recipe;

    public Sprite sprite;
    public string name;

    public void Gimme(Recipe recipe)
    {
        this.recipe = recipe;
        sprite = recipe.Sprite;
        name = recipe.name;
        this.gameObject.GetComponent<Image>().sprite = sprite;
    }

    public void OnMouseOver() // faire vers. UI
    {
        UIManager.Instance.ShowName(name);
    }
}
