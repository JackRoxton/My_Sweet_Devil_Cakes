using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickButton : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.GrannyPick(recipe);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.ShowName(name, sprite);
    }

}
