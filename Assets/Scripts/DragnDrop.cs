using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour
{
    public bool isDragged = false;

    public void OnMouseDrag()
    {
        isDragged = true;
        this.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void Update()
    {
        Debug.Log(isDragged);
        if (!Input.GetMouseButtonDown(0))
        {
            isDragged = false;
        }
    }

}
