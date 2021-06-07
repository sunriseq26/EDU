using System;
using UnityEngine;
using Random = System.Random;


namespace Asteroids
{
    public class EnemyMovement : IEnemyMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        public float Speed { get; }
        
        public Rigidbody2D Rigidbody { get; set; }

        public EnemyMovement(float speed, Rigidbody2D rigidbody)
        {
            Speed = speed;
            Rigidbody = rigidbody;
        }
        
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move = new Vector3(horizontal, horizontal, 0.0f);
            Rigidbody.AddForce(_move.normalized * speed, ForceMode2D.Impulse);
        }
    }
}