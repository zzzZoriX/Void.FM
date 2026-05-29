namespace Script.Player
{
    using UnityEngine;

    using Context = UnityEngine.InputSystem.InputAction.CallbackContext;


    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;
        private Inputs _inputs = null;


        public void Initialize() {
            _inputs = new Inputs();
            _inputs.Enable();

            _inputs.Player.Move.performed += OnMovePerformed;
            _inputs.Player.Move.canceled += OnMoveCanceled;

            _inputs.Player.Jump.performed += OnJumpPressed;
        }

        public void Deinitialize() {
            _inputs.Disable();

            _inputs.Player.Move.performed -= OnMovePerformed;
            _inputs.Player.Move.canceled -= OnMoveCanceled;

            _inputs.Player.Jump.performed -= OnJumpPressed;
        }

        private void OnMovePerformed(Context context) => _playerMovement.MoveVector = context.ReadValue<Vector2>();
        private void OnMoveCanceled(Context context) => _playerMovement.MoveVector = Vector2.zero;
        private void OnJumpPressed(Context context) => _playerMovement.Jump();
    }
}