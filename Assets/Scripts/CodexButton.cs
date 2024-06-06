using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class CodexButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image cadre;
    public List<Sprite> sprites;
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
        cadre.sprite = sprites[1];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cadre.sprite = sprites[0];
    }

    private void Start()
    {
        cadre = this.gameObject.GetComponent<Image>();
        image.sprite = recipe.Sprite;
    }
}
