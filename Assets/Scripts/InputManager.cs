using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public Texture2D open;
    public Texture2D closed;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(closed, Vector2.zero,CursorMode.ForceSoftware);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(open, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
