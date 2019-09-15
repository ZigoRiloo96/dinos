
using UnityEngine;

namespace riloo
{

    [CreateAssetMenu(fileName = "PoolObjectInfo", menuName = "riloo/PoolObjectInfo", order = 0)]
    public class PoolObjectInfo : ScriptableObject
    {
        public string pool_name;

        public int PoolKey
        {
            get { return Animator.StringToHash(pool_name); }
        }
    }

}