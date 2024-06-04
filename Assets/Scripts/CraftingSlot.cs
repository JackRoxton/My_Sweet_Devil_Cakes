using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSlot : MonoBehaviour
{
    public DragnDrop Ingredient;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;

        DragnDrop ingredient = collision.gameObject.GetComponent<DragnDrop>();

        if (ingredient == null) return;
        if (ingredient.isDragged) return;
        if (!ingredient.Draggable) return;

        ingredient.gameObject.transform.position = this.transform.position;

        ingredient.Draggable = false;
        this.Ingredient = ingredient;
    }

    public void Clear()
    {
        Ingredient = null;
    }
}
