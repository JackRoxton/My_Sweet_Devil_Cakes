using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour
{
    public bool isDragged = false;
    public bool Draggable = true;
    public Ingredient ingredient;

    public void OnMouseDrag()
    {
        if(!Draggable) return;
        isDragged = true;
        this.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            isDragged = false;
        }
    }

}
