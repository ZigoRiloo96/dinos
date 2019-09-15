
using UnityEngine;

public class MagnettoScript : MonoBehaviour
{
    private Transform target;

    private Vector3 dir;

    public float speed = 1f;

    private Vector3 collisionOffset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = collision.transform;
            collisionOffset = collision.offset;
        }
    }

    private void Update()
    {
        if (!target) return;

        dir = (target.position - transform.position + collisionOffset).normalized;

        transform.position += dir * speed * Time.deltaTime;

        speed += Time.deltaTime;
    }
}
