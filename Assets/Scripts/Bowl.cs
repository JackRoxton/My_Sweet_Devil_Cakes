using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public List<Ingredient> ingredients= new List<Ingredient>();
    public List<Transform> spots = new List<Transform>();

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;

        DragnDrop ingredient = collision.gameObject.GetComponent<DragnDrop>();

        if(ingredient == null) return;
        if(ingredient.isDragged) return;
        if(!ingredient.Draggable) return;
        if (ingredients.Count == 6) return;

        ingredient.gameObject.transform.position = spots[ingredients.Count].position;

        ingredient.Draggable = false;
        ingredients.Add(ingredient.ingredient);
    }

    public void Clear()
    {
        ingredients.Clear();
    }
}
