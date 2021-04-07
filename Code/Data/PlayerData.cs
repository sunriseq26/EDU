using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Code
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public Sprite Sprite;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(500, 1000)] private float _mouseSensitivity;
        [SerializeField] private Vector3 _position;
        public float Speed => _speed;

        public float MouseSensitivity => _mouseSensitivity;
        public Vector2 Position => _position;
    }
}