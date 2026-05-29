using System;
using UnityEngine;
using Script.Global;

namespace Script.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public Vector2 MoveVector;
        
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _jumpForce;
        
        [Header("Move speed")]
        [SerializeField] private float _minMoveSpeed;
        [SerializeField] private float _maxMoveSpeed;
        [SerializeField] private float _accelerationTime = 2f;
        [SerializeField] private float _decelerationTime = 2f;
        [SerializeField] private float _currentSpeed = 0f;
        
        private bool _canJump = true;


        private void Update() {
            Move();
            UpdateCanJumpStatus();
            MoveSpeedHandler();
        }

        public void Jump() {
            if (!_canJump) return;

            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        private void Move() {
            var horizontalDirection = Common.ConvertV2ToV3(MoveVector, 0f);
            var targetVelocity = Common.ConvertGlobalToLocal(horizontalDirection).normalized * _currentSpeed;

            _rigidbody.velocity = new Vector3(targetVelocity.x, _rigidbody.velocity.y, targetVelocity.z);
        }

        private void MoveSpeedHandler() {
            if (MoveVector == Vector2.zero) {
                MoveSpeedDecrease();
            }
            else {
                MoveSpeedIncrease();
            }
        }

        private void MoveSpeedIncrease() {
            var accelerationRate = (_maxMoveSpeed - _minMoveSpeed) / _accelerationTime;

            _currentSpeed = Mathf.MoveTowards(_currentSpeed, _maxMoveSpeed, accelerationRate * Time.deltaTime);
        }

        private void MoveSpeedDecrease() {
            var decelerationRate = (_maxMoveSpeed - _minMoveSpeed) / _decelerationTime;

            _currentSpeed = Mathf.MoveTowards(_currentSpeed, _minMoveSpeed, decelerationRate * Time.deltaTime);
        }

        private void UpdateCanJumpStatus() {
            _canJump = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }
    }
}