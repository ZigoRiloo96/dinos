
using System.Collections.Generic;
using UnityEngine;

namespace riloo
{

    public class ObjectPoolScript : Singelton<ObjectPoolScript>
    {
        private static Dictionary<int, Stack<GameObject>> pool = new Dictionary<int, Stack<GameObject>>();

        private static GameObject popedObject;

        public static void Push(GameObject go)
        {
            PoolObjectScript po = go.GetComponent<PoolObjectScript>();

            if (po == null)
            {
                Debug.LogError("No PoolObjectScript on object: " + go.name);
                Destroy(go);
                return;
            }

            PoolObjectInfo info = po.PoolObjectInfo;

            go.transform.SetParent(Instance.transform);
            go.SetActive(false);

            if (!pool.ContainsKey(info.PoolKey))
            {
                pool.Add(info.PoolKey, new Stack<GameObject>());
            }

            pool[info.PoolKey].Push(go);
        }

        public static GameObject Pop(GameObject _prefab, Vector3 _position, Quaternion _rotation = new Quaternion())
        {
            PoolObjectScript po = _prefab.GetComponent<PoolObjectScript>();

            if (po == null)
            {
                Debug.LogError("No PoolObjectScript on prefab: " + _prefab.name);
                return null;
            }

            PoolObjectInfo info = po.PoolObjectInfo;

            if (!pool.ContainsKey(info.PoolKey) || pool[info.PoolKey].Count == 0)
            {
                return Instantiate(_prefab);
            }

            popedObject = pool[info.PoolKey].Pop();

            popedObject.transform.SetParent(null);
            popedObject.transform.position = _position;
            popedObject.transform.rotation = _rotation;
            popedObject.SetActive(true);

            return popedObject;
        }
    }

}
