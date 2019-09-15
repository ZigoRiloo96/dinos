
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace riloo
{

    [RequireComponent(typeof(Button))]
    public class LoadButtonScript : MonoBehaviour
    {
        private Button button;

        public int SceneIndex = 0;

        public GameObject rootObject;

        private void Start()
        {
            button = GetComponent<Button>();

            button.onClick.AddListener(LoadScene);
        }

        private void LoadScene()
        {
            EventSystem.current.SetSelectedGameObject(null);

            SceneLoaderScript.LoadScene(SceneIndex, OnDone);
        }

        private void OnDone()
        {
            rootObject.SetActive(false);
        }
    }

}
