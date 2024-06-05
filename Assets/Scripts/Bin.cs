using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public Fridge fridge;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;

        DragnDrop ingredient = collision.gameObject.GetComponent<DragnDrop>();

        if (ingredient == null) return;
        if (ingredient.isDragged) return;

        fridge.SpawnClean(ingredient.gameObject);
        Destroy(ingredient.gameObject);
    }

}
