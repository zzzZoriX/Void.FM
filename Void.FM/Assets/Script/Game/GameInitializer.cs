using UnityEngine;

namespace Script.Game
{
    public class GameInitializer : MonoBehaviour
    {
        public Script.Player.Player Player;
        public GameObject CameraObject;
        
        
        private void Awake() {
            Player.Initialize();
            
            CameraObject.GetComponent<Script.Camera.CameraFollow>().Initialize(Player.transform);
            CameraObject.GetComponent<Script.Camera.CameraRotator>().Initialize(Player.transform);
        }

        private void OnDestroy() {
            Player.Deinitialize();
            
            CameraObject.GetComponent<Script.Camera.CameraRotator>().Deinitialize();
        }
    }
}