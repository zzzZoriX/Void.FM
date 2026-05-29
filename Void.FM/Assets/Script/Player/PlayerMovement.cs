using UnityEngine;
using Script.Global;

namespace Script.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Vector2 MoveVector;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _jumpForce;
        [SerializeField] private float _moveSpeed;
        
        private bool _canJump = true;


        private void Update() {
            Move();
            UpdateCanJumpStatus();
        }

        public void Jump() {
            if (!_canJump) return;

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void Move() {
            var horizontalDirection = Common.ConvertV2ToV3(MoveVector, 0f);
            var targetVelocity = Common.ConvertGlobalToLocal(horizontalDirection).normalized * _moveSpeed;

            _rigidbody.velocity = new Vector3(targetVelocity.x, _rigidbody.velocity.y, targetVelocity.z);
        }

        private void UpdateCanJumpStatus() {
            _canJump = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }
    }
}