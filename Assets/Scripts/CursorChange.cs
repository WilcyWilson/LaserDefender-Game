using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture = default;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
