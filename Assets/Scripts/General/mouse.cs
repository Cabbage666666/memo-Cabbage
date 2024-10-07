using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
        //要替换的光标图片
    public Texture2D Texture2D;
 
    // Use this for initialization
    void Update () 
    {
        Cursor.SetCursor(Texture2D, Vector2.zero, CursorMode.Auto);
    }
 
}
