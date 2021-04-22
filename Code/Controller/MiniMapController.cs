using UnityEngine;

namespace Code
{
    public class MiniMapController : IExecute, ICleanup
    {
        private Transform _unit;
        private Camera _miniMapCamera;
        
        public MiniMapController(Transform unit, Camera camera)
        {
            _unit = unit;
            _miniMapCamera = camera;
        }
        
        public void Execute(float deltaTime)
        {
            var positionCamera = _unit.position;
            positionCamera.y = _miniMapCamera.transform.position.y;
            _miniMapCamera.transform.position = positionCamera;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90, _unit.eulerAngles.y, 0);
        }

        public void Cleanup()
        {
        }
    }
}