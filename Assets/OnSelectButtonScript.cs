
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnSelectButtonScript : MonoBehaviour, ISelectHandler
{
    private bool shine = false;

    private Material material;

    private float value = 0f;

    private float speed = 2f;

    private void Awake()
    {
        material = GetComponent<Image>().material;

        GetComponent<Image>().material = new Material(material);

        material = GetComponent<Image>().material;
    }

    public void Shine()
    {
        value = 0f;
        shine = true;
    }

    void ISelectHandler.OnSelect(BaseEventData eventData)
    {
        Shine();
    }

    private void Update()
    {
        if (!shine) return;

        if (value >= 1f)
        {
            material.SetFloat("_ShineLocation", 1f);

            value = 0f;

            shine = false;
        }

        material.SetFloat("_ShineLocation", value);

        value += Time.deltaTime * speed;
    }
}
