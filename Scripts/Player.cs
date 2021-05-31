using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IDataPlayer
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _health;
        [SerializeField] private float _maximumHealth;
        // [SerializeField] private Rigidbody2D _bullet;
        // [SerializeField] private Transform _barrel;
        // [SerializeField] private float _forceBullet;
        //private Rigidbody2D _rigidbodyPlayer;
        private PlayerHealth _playerHealth;
        
        private float _damage = 2;

        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public Rigidbody2D RigidbodyPlayer { get; private set; }
        public Transform TransformPlayer { get; private set; }

        private void Awake()
        {
            //_camera = Camera.main;
            //var moveTransform = new AccelerationMove(transform, _speed, _acceleration, _rigidbodyPlayer);
            //var rotation = new RotationShip(transform);
            RigidbodyPlayer = GetComponent<Rigidbody2D>();
            TransformPlayer = transform;
            _playerHealth = new PlayerHealth(_health, _maximumHealth);
        }

        

        private void OnCollisionEnter2D(Collision2D other)
        {
            _playerHealth.TakeDamage(_damage);
        }
    }
}
