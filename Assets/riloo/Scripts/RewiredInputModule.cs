
using UnityEngine;
using Rewired;

namespace riloo
{

    [RequireComponent(typeof(InputManager))]
    public class RewiredInputModule : MonoBehaviour
    {
        static Player system_player;

        void Start()
        {
            system_player = ReInput.players.GetPlayer(RewiredConsts.Player.System);

            OnConnect();

            Rewired.ReInput.ControllerConnectedEvent += OnConnect;
        }

        private void OnConnect(ControllerStatusChangedEventArgs _args = null)
        {
            for (int i = 0; i < ReInput.controllers.Joysticks.Count; i++)
            {
                //Debug.Log(i + " ControllerId: " + ReInput.controllers.Joysticks[i].systemId + " id: " + ReInput.controllers.Joysticks[i].id +
                //    " unityId: " + ReInput.controllers.Joysticks[i].unityId);

                ReInput.players.Players[i].controllers.AddController(ReInput.controllers.Joysticks[i], true); 
            }
        }

        public static bool GetButtonDown(int id, int action)
        {
            return ReInput.players.Players[id].GetButtonDown(action);
        }

        public static bool GetButtonUp(int id, int action)
        {
            return ReInput.players.Players[id].GetButtonUp(action);
        }

        public static bool GetButton(int id, int action)
        {
            return ReInput.players.Players[id].GetButton(action);
        }

        public static float GetAxis(int id, int action)
        {
            return ReInput.players.Players[id].GetAxisRaw(action);
        }

        public static Vector2 GetAxis2D(int id, int x_action, int y_action)
        {
            return ReInput.players.Players[id].GetAxis2D(x_action, y_action);
        }

        public static bool GetButtonDown(int action)
        {
            return system_player.GetButtonDown(action);
        }

        public static bool GetButtonUp(int action)
        {
            return system_player.GetButtonUp(action);
        }

        public static bool GetButton(int action)
        {
            return system_player.GetButton(action);
        }

        public static float GetAxis(int action)
        {
            return system_player.GetAxisRaw(action);
        }

        public static Vector2 GetAxis2D(int x_action, int y_action)
        {
            return system_player.GetAxis2D(x_action, y_action);
        }

        public static Player GetRewiredPlayer(int id)
        {
            return ReInput.players.GetPlayer(id);
        }
    }

}