using UnityEngine;

namespace riloo
{

    public class Singelton<T> : MonoBehaviour where T : Singelton<T>
    {
        public static T Instance = null;

        void Start()
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            Init();
        }

        protected virtual void Init()
        {
            Debug.Log("Init singelton: " + gameObject.name);
        }
    }

}
