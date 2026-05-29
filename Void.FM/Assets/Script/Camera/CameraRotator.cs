using System;
using UnityEngine;

namespace Script.Camera
{
    public class CameraRotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        private Transform _player;
        private Inputs _inputs = null;
        
        /* Parameters */
        private float _maxVerticalAngle = 90f;
        private float _minVerticalAngle = -90f;
        private float _xRotation = 0f;
        private float _yRotation = 0f;


        private void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update() {
            Rotate();
        }

        public void Initialize(Transform player) {
            _player = player;

            _inputs = new Inputs();
            _inputs.Enable();
        }

        public void Deinitialize() {
            _inputs.Disable();
        }

        private void Rotate() {
            if (_inputs == null) return;

            var rotationDelta = _inputs.Camera.Rotation.ReadValue<Vector2>();

            var mouseX = rotationDelta.x * _sensitivity;
            var mouseY = rotationDelta.y * _sensitivity;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, _minVerticalAngle, _maxVerticalAngle);

            _yRotation += mouseX;
            
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
            
            _player.Rotate(Vector3.up * mouseX);
        }
    }
}