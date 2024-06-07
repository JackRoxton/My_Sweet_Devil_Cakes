using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameBowl : MonoBehaviour
{
    public bool turning = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision != null)
        {
            Spatula spatula = collision.gameObject.GetComponent<Spatula>();
            if (spatula != null && spatula.isDragged)
            {
                turning = true;
            }
            else
            {
                turning = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            Spatula spatula = collision.gameObject.GetComponent<Spatula>();
            if (spatula != null)
            {
                turning = false;
            }
        }
    }
}
