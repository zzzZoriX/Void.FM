using System;
using UnityEngine;

namespace Script.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        private Transform _target;


        private void FixedUpdate() {
            Follow();
        }

        public void Initialize(Transform target) {
            _target = target;
        }

        private void Follow() {
            transform.position = Vector3.Lerp(transform.position, _target.position + _offset, 1f);
        }
    }
}