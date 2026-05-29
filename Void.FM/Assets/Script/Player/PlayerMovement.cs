namespace Script.Player
{
    using UnityEngine;
    using Script.Global;

    using Context = UnityEngine.InputSystem.InputAction.CallbackContext;


    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _moveSpeed;
    
        private Vector2 _moveVector;
        private Inputs _inputs = null;


        private void Update() {
            Move();
        }

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

        private void Jump() {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void Move() {
            var horizontalDirection = Common.ConvertV2ToV3(_moveVector, 0f);
            var targetVelocity = Common.ConvertGlobalToLocal(horizontalDirection).normalized * _moveSpeed;

            _rigidbody.velocity = new Vector3(targetVelocity.x, _rigidbody.velocity.y, targetVelocity.z);
        }

        private void OnMovePerformed(Context context) => _moveVector = context.ReadValue<Vector2>();
        private void OnMoveCanceled(Context context) => _moveVector = Vector2.zero;
        private void OnJumpPressed(Context context) => Jump();
    }
}