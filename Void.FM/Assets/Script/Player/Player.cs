namespace Script.Player
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;


        public void Initialize() {
            playerController.Initialize();
        }

        public void Deinitialize() {
            playerController.Deinitialize();
        }
    }
}