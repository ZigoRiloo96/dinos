
using UnityEngine;

namespace riloo
{

    public class MovementScript : MonoBehaviour
    {

        private void Awake()
        {
            SpeedAnimatorId = Animator.StringToHash("Speed");
        }

        private int SpeedAnimatorId;

        // public SpriteAnimationScript animationScript;
        public Animator m_Animatior;

        public float m_Speed = 1f;

        private Vector2 direction;
        private Vector3 velocity;

        Vector2Int inputDir = Vector2Int.zero;
        Vector2 prev_direction = Vector2.zero;

        public Rigidbody2D rb;

        public SpriteRenderer spriteRenderer;

        private bool flip = false;
        private bool prevFlip = false;

        public int m_PlayerID;

        private void Update()
        {
            if (!m_Animatior.GetCurrentAnimatorStateInfo(0).IsTag("action"))
            {
                if (RewiredInputModule.GetButtonDown(m_PlayerID, RewiredConsts.Action.Game_Attack_1) || RewiredInputModule.GetButtonDown(RewiredConsts.Action.Game_Attack_1))
                {
                    // attack
                    m_Animatior.SetTrigger("Attack");
                }

                direction = RewiredInputModule.GetAxis2D(m_PlayerID, RewiredConsts.Action.Game_MoveHorizontal, RewiredConsts.Action.Game_MoveVertical);

                inputDir.x = direction.x > 0f ? 1 : direction.x < 0f ? -1 : 0;
                inputDir.y = direction.y > 0f ? 1 : direction.y < 0f ? -1 : 0;

                if (inputDir == Vector2.zero)
                {
                    direction = RewiredInputModule.GetAxis2D(RewiredConsts.Action.Game_MoveHorizontal, RewiredConsts.Action.Game_MoveVertical);

                    inputDir.x = direction.x > 0f ? 1 : direction.x < 0f ? -1 : 0;
                    inputDir.y = direction.y > 0f ? 1 : direction.y < 0f ? -1 : 0;
                }

                //
                if (direction != prev_direction)
                {
                    //animationScript.PlayAnimationByDirection(direction, inputDir);
                    m_Animatior.SetFloat(SpeedAnimatorId, inputDir.magnitude);
                }
                //

                flip = direction.x > 0f ? false : direction.x < 0f ? true : prevFlip;

                if (flip != prevFlip)
                {
                    spriteRenderer.flipX = direction.x > 0f ? false : direction.x < 0f ? true : prevFlip;
                    prevFlip = spriteRenderer.flipX;
                }

                prev_direction = direction;

                velocity = direction * m_Speed;

                //transform.position += velocity * Time.fixedDeltaTime;

                rb.velocity = velocity; //* Time.fixedDeltaTime;
            }
            else
            {
                m_Animatior.SetFloat(SpeedAnimatorId, 0f);
                prev_direction = Vector2.zero;
                rb.velocity = prev_direction;
            }
        }
    }

}