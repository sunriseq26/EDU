﻿using System;
using UnityEngine;

namespace Code
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy
    {
        public event Action<int> OnTriggerEnterChange;

        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private int _takeDamage = 10;
        private Rigidbody _rigidbody;
        private Transform _transform;
        private IView _view;
        protected IHealth _health;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _transform = transform;
        }

        public void Move(Vector3 point)
        {
            if ((_transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.localPosition).normalized;
                _rigidbody.velocity = dir * _speed;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }
            OnTriggerEnterChange?.Invoke(_takeDamage);
            _view.Display(_view.FirstKeyText, _health.PlayerHealth, _view.FirstText);
        }
        
        public void Initialization(IView view, IHealth health)
        {
            _view = view;
            _health = health;
        }
    }
}