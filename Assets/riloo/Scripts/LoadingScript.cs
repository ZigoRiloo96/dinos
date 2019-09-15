using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace riloo
{

    public class LoadingScript : Singelton<LoadingScript>
    {
        public Image LoadingImage;

        private static Image loadingImage;

        private void Start()
        {
            loadingImage = LoadingImage;
        }

        public static void Show()
        {
            loadingImage.gameObject.SetActive(true);
        }

        public static void Hide()
        {
            Instance.StartCoroutine(HideLoading());
        }

        private static IEnumerator HideLoading()
        {
            yield return new WaitForSecondsRealtime(1f);
            loadingImage.gameObject.SetActive(false);
        }
    }

}
