using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    List<Ingredient> ingredients= new List<Ingredient>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;

        DragnDrop ingredient = collision.gameObject.GetComponent<DragnDrop>();

        if(ingredient == null) return;
        if(ingredient.isDragged) return;
        if(!ingredient.Draggable) return;

        ingredient.Draggable = false;
        ingredients.Add(ingredient.ingredient);

        //check recette
    }
}
