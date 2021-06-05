using System;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IDataPlayer
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _health;
        [SerializeField] private float _maximumHealth;
        
        private IDamage _playerHealth;
        
        private float _damage = 2;

        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public Rigidbody2D RigidbodyPlayer { get; private set; }
        public Transform TransformPlayer { get; private set; }

        private void Awake()
        {
            RigidbodyPlayer = GetComponent<Rigidbody2D>();
            TransformPlayer = transform;
            _playerHealth = new PlayerHealth(_health, _maximumHealth);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!FindObjectOfType<Bullet>())
            {
                _playerHealth.TakeDamage(_damage);
            }
        }
    }
}
