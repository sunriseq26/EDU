﻿using System;
using UnityEngine;

namespace Code
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private Rigidbody _rigidbody2D;
        private Transform _transform;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.localPosition).normalized;
                _rigidbody2D.velocity = dir * _speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID());
        }
    }
}