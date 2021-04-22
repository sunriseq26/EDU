using System;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IUnit
    {
        public GameObject Player;
        [SerializeField, Range(0, 100)]private int _valueHealth;
        [SerializeField, Range(0, 500)]private int _maximumValueHealth;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField, Range(500, 1000)] private float _mouseSensitivity;
        [SerializeField] private Vector3 _position;
        [SerializeField] private DataRidgidbody _dataRidgidbody;
        //[SerializeField] private DataHealth _dataHealth;
        
        
        public float Speed => _speed;
        public float MouseSensitivity => _mouseSensitivity;
        public Vector3 Position => _position;
        public float Mass => _dataRidgidbody._mass;
        public float AngularDrag => _dataRidgidbody._angularDrag;
        public bool IsGravity => _dataRidgidbody._isGravity;
        public bool IsFreeze => _dataRidgidbody._isFreeze;
        public int MaximumValueHealth => _maximumValueHealth;
        public int ValueHealth => _valueHealth;
    }
    
    [Serializable]
    struct DataRidgidbody
    {
        [SerializeField, Range(0, 100)] internal float _mass;
        [SerializeField, Range(0, 10)] internal float _angularDrag;
        public bool _isGravity;
        public bool _isFreeze;
    }
    
    [Serializable]
    struct DataHealth
    {
        [SerializeField, Range(0, 500)] internal int _maximumValueHealth;
        [SerializeField, Range(0, 200)] internal int _valueHealth;
    }
}