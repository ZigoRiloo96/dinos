
using UnityEngine;

namespace riloo
{

    public class AudioListenerScript : Singelton<AudioListenerScript>
    {
        private Vector3 cameraPos;

        private void Update()
        {
            if (cameraPos != Camera.main.gameObject.transform.position)
            {
                cameraPos = Camera.main.gameObject.transform.position;

                transform.position = cameraPos;
            }
        }
    }

}
