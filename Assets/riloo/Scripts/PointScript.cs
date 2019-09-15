
using UnityEngine;

namespace riloo
{

    public class PointScript : MonoBehaviour
    {
        private float lifeTime = 3f;

        private void Update()
        {
            lifeTime -= Time.deltaTime;

            if (lifeTime < 0)
            {
                Hide();
            }
        }

        public void Hide()
        {
            ObjectPoolScript.Push(gameObject);
        }
    }

}
