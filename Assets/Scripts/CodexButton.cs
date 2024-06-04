using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CodexButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    public Recipe recipe;
    public Image image;
    public int quality = 0;
    public Image stars;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.SetPickedRecipe(recipe);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.PokedexShowHover(recipe);
    }

    private void Start()
    {
        image.sprite = recipe.Sprite;
    }
}
