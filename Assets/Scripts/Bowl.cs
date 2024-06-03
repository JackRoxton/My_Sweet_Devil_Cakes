using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == null) return;

        Ingredient ingredient = collision.gameObject.GetComponent<Ingredient>();

        if(ingredient == null) return;
        if(collision.gameObject.GetComponent<DragnDrop>().isDragged) return;


    }
}
