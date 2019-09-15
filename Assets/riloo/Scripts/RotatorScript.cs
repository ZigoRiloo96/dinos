
using UnityEngine;

public class RotatorScript : MonoBehaviour
{
    public float speed = 4f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, speed);
    }
}
