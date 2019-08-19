
using UnityEngine;

namespace riloo
{

    public class SortObjectScript : MonoBehaviour
    {
        public bool StaticObject = true;

        private Vector3 current_position;

        private Vector3 prev_position;

        private const float ACT_MIN_Z_VALUE = -9;
        private const float ACT_MAX_Z_VALUE = 5;

        private const float MIN_Z_VALUE = -3;
        private const float MAX_Z_VALUE = -2;

        private float normalizePos = 0;

        private float AVG_Z_VALUE = MAX_Z_VALUE - MIN_Z_VALUE;
        private float AVG_ACT_Z_VALUE = ACT_MAX_Z_VALUE - ACT_MIN_Z_VALUE;

        public float offset = 0f;

        private void Awake()
        {
            Clac();
        }

        private void Update()
        {
            if (StaticObject) return;

            Clac();

            if (prev_position == current_position) return;

            transform.position = current_position;

            prev_position = current_position;
        }

        private void Clac()
        {
            current_position = transform.position;

            normalizePos = current_position.y - ACT_MIN_Z_VALUE;

            float f = normalizePos / AVG_ACT_Z_VALUE;

            float f1 = MIN_Z_VALUE + (f * AVG_Z_VALUE);

            current_position.z = f1 + offset;
        }
    }

}