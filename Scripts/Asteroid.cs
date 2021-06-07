using System;
using UnityEngine;

namespace Asteroids
{
    [Serializable]
    public sealed class Asteroid : Enemy, IEnemyMove
    {
        private Vector3 _move;
        public float Speed { get; private set; } = 2;
        public Rigidbody2D Rigidbody { get; set; }
        
        public void DependencyInjectHealth(Health hp, float speed)
        {
            Health = hp;
            Speed = speed;
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            transform.localPosition += _move;
        }

        protected override void OnBecameInvisible()
        {
            
            ReturnToPool();
            Asteroid asteroidNew = this.DeepCopy();
            asteroidNew.transform.position = Vector3.one;
        }
    }
}
