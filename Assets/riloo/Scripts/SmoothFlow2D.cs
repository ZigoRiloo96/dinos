
using UnityEngine;

namespace riloo
{

    public class SmoothFlow2D : MonoBehaviour
    {
        public Camera m_Camera;
        public float m_DampTime = 0.15f;
        public Transform m_Target;

        private Vector3 velocity = Vector3.zero;
        private Vector3 point, delta, destination, targetPosition;

        private Vector3 _vector = new Vector3(0.5f, 0.5f, 0f);

        private Vector2 d, p;

        void Update()
        {
            if (m_Target)
            {
                point = m_Camera.WorldToViewportPoint(m_Target.position);

                _vector.z = point.z;

                delta = m_Target.position - m_Camera.ViewportToWorldPoint(_vector);

                destination = transform.position + delta;

                d = destination;
                p = transform.position;

                if (Vector2.Distance(d, p) < 0.1f)
                {
                    return;
                }

                transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, m_DampTime);
            }
        }
    }

}