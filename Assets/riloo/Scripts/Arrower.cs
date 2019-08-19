
using UnityEngine;

public class Arrower : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;
    public float distance = 1f;
    public Camera m_Camera;
    public RectTransform CanvasRect;

    public RectTransform[] arrows;
    public Transform[] players;

    private Vector2 norm_direction = Vector2.zero;

    float angle = 0f;

    private Vector3 angles = Vector3.zero;

    //Vector2 WorldObject_ScreenPosition;

    Vector2 screenPosition;

    private void Update()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (players[i].gameObject.activeSelf && !players[i].GetChild(0).GetComponent<SpriteRenderer>().isVisible)
            {
                if (!arrows[i].gameObject.activeSelf)
                {
                    arrows[i].gameObject.SetActive(true);
                }
            }
            else
            {
                if (arrows[i].gameObject.activeSelf)
                {
                    arrows[i].gameObject.SetActive(false);
                }

                continue;
            }

            direction = m_Camera.WorldToViewportPoint(players[i].position);

            //if (CanvasRect. direction)

            screenPosition.x = direction.x * CanvasRect.sizeDelta.x;
            screenPosition.y = direction.y * CanvasRect.sizeDelta.y;

            //screenPosition.y = -screenPosition.y;

            //WorldObject_ScreenPosition.x = ((direction.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f));
            //WorldObject_ScreenPosition.y = ((direction.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f));

            norm_direction = (screenPosition - (Vector2)transform.position).normalized;

            arrows[i].localPosition = norm_direction * distance;

            angle = Mathf.Atan(norm_direction.y / norm_direction.x) * Mathf.Rad2Deg;

            if (float.IsNaN(angle))
            {
                return;
            }

            angles.z = norm_direction.x > 0 ? 180f + angle : angle;

            arrows[i].localEulerAngles = angles;
        }
    }
}
