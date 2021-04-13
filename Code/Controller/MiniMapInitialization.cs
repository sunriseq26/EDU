using UnityEngine;

namespace Code
{
    public class MiniMapInitialization : IInitialization
    {
        private Transform _unit;
        private Camera _miniMapCamera;
        
        public MiniMapInitialization(Transform unit)
        {
            _unit = unit;
            _miniMapCamera = new GameObject("MiniMap").AddComponentCamera();
            _miniMapCamera.transform.parent = null;
            _miniMapCamera.transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            _miniMapCamera.transform.position = _unit.position + new Vector3(0, 5.0f, 0);

            var renderTextureMask = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
            _miniMapCamera.targetTexture = renderTextureMask;

        }
        public void Initialization()
        {
        }
        
        public Camera GetMiniMap()
        {
            return _miniMapCamera;
        }
    }
}