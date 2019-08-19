
using UnityEngine;

namespace riloo
{

    public enum AttackType
    {
        LIGHT = RewiredConsts.Action.Game_Attack_1,
        HEAVY = RewiredConsts.Action.Game_Attack_2
    }

    public class AttackScript : MonoBehaviour
    {
        // public SpriteAnimationScript AnimationScript;

        public AttackTriggersManager AttackTriggersManager;

        private GameObject[] objectsToAttack;
        private Rigidbody2D entityScriptToAttack;

        //private EntityScript entityScript;

        //private void Awake()
        //{
        //    // TODO: init player so
        //}

        public SpriteRenderer m_Renderer;

        public float force = 10f;

        public Animator m_Animator;

        private void Attack(AttackType type)
        {
            objectsToAttack = AttackTriggersManager.GetObjects(m_Renderer.flipX);

            for (int i = 0; i < objectsToAttack.Length; i++)
            {
                entityScriptToAttack = objectsToAttack[i].GetComponent<Rigidbody2D>();

                if (entityScriptToAttack)
                {
                    entityScriptToAttack.GetComponent<MovementScript>().m_Animatior.SetTrigger("Hit");

                    entityScriptToAttack.GetComponent<PlayerScript>().TakeDanage(10, 20);

                    entityScriptToAttack.AddForce((entityScriptToAttack.transform.position - transform.position).normalized * force, ForceMode2D.Force);
                }
            }
        }

        //private void OnAttackComplete()
        //{
        //    attackComplete = true;
        //}

        public int m_PlayerID;

        private void Update()
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsTag("action")) return;

            if (RewiredInputModule.GetButtonDown(m_PlayerID, RewiredConsts.Action.Game_Attack_1) || RewiredInputModule.GetButtonDown(RewiredConsts.Action.Game_Attack_1))
            {
                // attack
                Attack(AttackType.LIGHT);
                //m_Animatior.SetTrigger("Attack");
            }
        }
    }

}