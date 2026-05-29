using System;
using UnityEngine;

namespace Script.Game
{
    public class GameInitializer : MonoBehaviour
    {
        public Player Player;
        
        
        private void Awake() {
            Player.Initialize();
        }

        private void OnDestroy() {
            Player.Deinitialize();
        }
    }
}