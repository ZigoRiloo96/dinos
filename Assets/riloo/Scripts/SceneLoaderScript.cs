
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace riloo
{
    public class SceneLoaderScript : Singelton<SceneLoaderScript>
    {
        private static AsyncOperation async_op;

        private static UnityAction OnLoadDoneAction;

        private static bool single = false;

        public static void LoadScene(int index, UnityAction onDone, bool _single = false)
        {
            OnLoadDoneAction = onDone;
            single = _single;
            Instance.StartCoroutine(loadScene(index));
        }

        private static IEnumerator loadScene(int index)
        {
            async_op = SceneManager.LoadSceneAsync(index, single ? LoadSceneMode.Single : LoadSceneMode.Additive);

            riloo.LoadingScript.Show();
            async_op.completed += OnLoadIsDone;

            yield return async_op;
        }

        private static void OnLoadIsDone(AsyncOperation async)
        {
            riloo.LoadingScript.Hide();

            OnLoadDoneAction.Invoke();
        }
    }
}