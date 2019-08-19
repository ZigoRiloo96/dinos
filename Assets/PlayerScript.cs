
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float m_Health = 100f;

    public Animator m_Animator;

    private bool dead = false;

    public riloo.MovementScript movementScript;

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

        m_Health -= Random.Range(_damageMin, _damageMax);

        if (m_Health < 0f)
        {
            m_Health = 0f;

            Die();
        }
    }

    private void Die()
    {
        // DIE
        dead = true;
        GetComponent<Collider2D>().enabled = false;
        movementScript.enabled = false;
        shadow.SetActive(false);
        m_Animator.SetTrigger("Die");
    }
}
