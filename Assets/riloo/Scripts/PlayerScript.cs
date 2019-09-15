
using UnityEngine;

namespace riloo
{

    public class PlayerScript : MonoBehaviour
    {
        private float m_Health = 50f;

        public Animator m_Animator;

        private bool dead = false;

        public riloo.MovementScript movementScript;

        public PointsSpawner pointsSpawner;

        public GameObject shadow;

        public void Reset()
        {
            m_Health = 100f;
            dead = false;
            movementScript.enabled = true;
            shadow.SetActive(true);
            GetComponent<Collider2D>().enabled = true;
        }

        public void TakeDanage(float _damageMin, float _damageMax)
        {
            if (dead) return;

            float currentDamage = Random.Range(_damageMin, _damageMax);

            float random = Random.Range(0.2f, 1f);

            float healthBeforeDamage = m_Health;

            m_Health -= currentDamage;

            if (m_Health < 0f)
            {
                m_Health = 0f;

                pointsSpawner.SpawnPoints((uint)(healthBeforeDamage * 0.8f * random));

                Die();
            }
            else
            {
                pointsSpawner.SpawnPoints((uint)(currentDamage * 0.8f * random), 1f);
            }
        }

        private void Die()
        {
            dead = true;
            GetComponent<Collider2D>().enabled = false;
            movementScript.enabled = false;
            shadow.SetActive(false);
            m_Animator.SetTrigger("Die");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Point")
            {
                collision.gameObject.GetComponent<PointScript>().Hide();

                m_Health += 1;
            }
        }
    }

}
