
using UnityEngine;

namespace riloo
{

    public enum AttackTriggerType
    {
        LEFT = 0,
        RIGHT = 1
    }

    public class AttackTriggersManager : MonoBehaviour
    {
        private AttackTriggerScript[] attackTriggerScripts;

        private void Awake()
        {
            attackTriggerScripts = new AttackTriggerScript[2];

            attackTriggerScripts = GetComponentsInChildren<AttackTriggerScript>();

            //for (int i = 0; i < attackTriggerScripts.Length; i++)
            //{
            //    attackTriggerScripts[i] = transform.GetChild(i).gameObject.GetComponent<AttackTriggerScript>();
            //}
        }

        public GameObject[] GetObjects(bool flip)
        {
            return attackTriggerScripts[flip ? 0 : 1].GetObjects();
        }
    }

}