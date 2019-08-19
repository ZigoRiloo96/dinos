
using System.Collections.Generic;
using UnityEngine;

namespace riloo
{

    public class AttackTriggerScript : MonoBehaviour
    {
        private List<GameObject> objectsInTrigger = new List<GameObject>();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            objectsInTrigger.Add(collision.gameObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            objectsInTrigger.Remove(collision.gameObject);
        }

        public GameObject[] GetObjects()
        {
            return objectsInTrigger.ToArray();
        }
    }

}