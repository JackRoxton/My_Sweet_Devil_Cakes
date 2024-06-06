using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour
{
    public bool Draggable = true;
    public bool isDragged = false;

    private void Update()
    {
        if(!Input.GetMouseButtonDown(0))
        {
            isDragged = false;
        }
    }
    public void OnMouseDrag()
    {
        if (!Draggable) return;
        isDragged = true;
        this.transform.up = new Vector3(0,-4,0) - this.transform.position;
        this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        
    }

}
