using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPoint : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    public void SetColor(Color color)
    {
        spriteRenderer.color = color;
    }
    
    public void SetSize(float size)
    {
        //  小さく表示するように
        transform.localScale = new Vector3(size, size, size) / 10;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
