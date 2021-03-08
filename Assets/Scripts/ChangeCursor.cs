using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Texture2D cursorArrow;
    
    void Start()
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    
    
    //void OnMouseEnter()
    //{
    //    Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    //}

    //void OnMouseExit()
    //{
    //    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    //}
    
}
