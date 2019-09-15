
using UnityEngine;

namespace riloo
{

    public class ScreenManager : MonoBehaviour
    {
        Vector2Int lastScreenSize, screenSize;

        int y = 1080;
        int ratio = 64;

        private UnityEngine.Experimental.Rendering.LWRP.PixelPerfectCamera pixelPerfectCamera;

        void Awake()
        {
            lastScreenSize = new Vector2Int(Screen.width, Screen.height);

            pixelPerfectCamera = GetComponent<UnityEngine.Experimental.Rendering.LWRP.PixelPerfectCamera>();

            pixelPerfectCamera.refResolutionX = lastScreenSize.x;
            pixelPerfectCamera.refResolutionY = lastScreenSize.y;

            pixelPerfectCamera.assetsPPU = (int)(((float)lastScreenSize.y / y) * ratio);
        }

        void Update()
        {
            screenSize.x = Screen.width;
            screenSize.y = Screen.height;

            if (this.lastScreenSize != screenSize)
            {
                pixelPerfectCamera.refResolutionX = screenSize.x;
                pixelPerfectCamera.refResolutionY = screenSize.y;

                pixelPerfectCamera.assetsPPU = (int)(((float)screenSize.y / y) * ratio);

                this.lastScreenSize = screenSize;
            }

            //if (riloo.RewiredInputModule.GetButton(1, RewiredConsts.Action.Game_Attack_1) &&
            //    riloo.RewiredInputModule.GetButtonDown(1, RewiredConsts.Action.Game_Attack_2))
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneLoaderScript.LoadScene(2, OnDone, true);
            }
        }

        private void OnDone()
        {

        }
    }

}
