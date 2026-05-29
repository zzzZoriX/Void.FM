namespace Script.Player
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;


        public void Initialize() {
            _playerMovement.Initialize();
        }

        public void Deinitialize() {
            _playerMovement.Deinitialize();
        }
    }
}