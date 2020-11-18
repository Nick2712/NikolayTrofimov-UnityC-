using UnityEngine;


namespace NikolayTrofimov_Game
{
    public sealed class CameraController : IExecute
    {
        private readonly Transform _player;
        private readonly Transform _mainCamera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;

            //с этим неудобно управлять объектом
            //_mainCamera.LookAt(_player);
            _offset = _mainCamera.position - _player.position;
        }

        public void Execute(float timeDeltatime)
        {
            _mainCamera.position = _player.position + _offset;
        }
    }
}