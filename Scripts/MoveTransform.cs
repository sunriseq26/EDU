using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;

        public float Speed { get; protected set; }
        public Rigidbody2D Rigidbody { get; set;}

        public MoveTransform(Transform transform, float speed, Rigidbody2D rigidbody)
        {
            _transform = transform;
            Speed = speed;
            Rigidbody = rigidbody;
        }

        public void Move(float horizontal, float vertical,  float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move = new Vector3(horizontal, vertical, 0.0f);
            Rigidbody.AddForce(_move * speed, ForceMode2D.Impulse);
        }
    }
}
