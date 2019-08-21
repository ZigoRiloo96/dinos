
using UnityEngine;

public class SpriteCloner : MonoBehaviour
{

    public SpriteRenderer m_InSpriteRenderer;

    public Transform m_InTransform;

    private SpriteRenderer m_OutSpriteRenderer;

    public Color FillColor;

    void Start()
    {
        m_OutSpriteRenderer = GetComponent<SpriteRenderer>();

        m_OutSpriteRenderer.material.SetColor("_Color", FillColor);
    }

    void Update()
    {
        transform.position = m_InTransform.position;

        if (m_OutSpriteRenderer.sprite == m_InSpriteRenderer.sprite && FillColor.a == m_InSpriteRenderer.color.a && m_OutSpriteRenderer.flipX != m_InSpriteRenderer.flipX) return;

        FillColor.a = m_InSpriteRenderer.color.a;

        m_OutSpriteRenderer.flipX = m_InSpriteRenderer.flipX;

        m_OutSpriteRenderer.material.SetColor("_Color", FillColor);

        m_OutSpriteRenderer.sprite = m_InSpriteRenderer.sprite;
    }
}
