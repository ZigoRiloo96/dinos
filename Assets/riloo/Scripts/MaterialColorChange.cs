
using UnityEngine;

public class MaterialColorChange : MonoBehaviour
{
    public Color FillColor;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetColor("_Color", FillColor);
    }
}
