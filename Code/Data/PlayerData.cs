using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Code
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public GameObject Player;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(500, 1000)] private float _mouseSensitivity;
        [SerializeField, Range(0, 100)] private float _mass;
        [SerializeField, Range(0, 10)] private float _angularDrag;
        [SerializeField] private bool _isGravity;
        [SerializeField] private bool _isFreeze;
        [SerializeField] private Vector3 _position;
        public float Speed => _speed;
        public float MouseSensitivity => _mouseSensitivity;
        public float Mass => _mass;
        public float AngularDrag => _angularDrag;
        public bool IsGravity => _isGravity;
        public bool IsFreeze => _isFreeze;
        public Vector3 Position => _position;
    }
}