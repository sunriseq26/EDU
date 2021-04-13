using UnityEngine;

namespace Code
{
    internal sealed class CameraController : ILateExecute
    {
        private readonly Transform _player;
        private readonly Transform _mainCamera;
        private readonly Vector3 _offset;
        private readonly float _angelRotationX = 27.5f;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _offset = _mainCamera.position - _player.position;
        }

        public void LateExecute(float deltaTime)
        {
            _mainCamera.rotation = Quaternion.Euler(_angelRotationX, _player.rotation.eulerAngles.y, _mainCamera.rotation.z);
            _mainCamera.position = _player.localRotation * _offset + _player.position;
        }
    }
}