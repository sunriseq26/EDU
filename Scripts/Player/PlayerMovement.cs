using UnityEngine;

namespace Asteroids
{
    internal class PlayerMovement : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;

        public float Speed { get; protected set; }
        public Rigidbody2D Rigidbody { get; set;}

        public PlayerMovement(Transform transform, float speed, Rigidbody2D rigidbody)
        {
            _transform = transform;
            Speed = speed;
            Rigidbody = rigidbody;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        public void MovePhysics(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move = new Vector3(horizontal, vertical, 0.0f);
            Debug.Log(_move);
            Rigidbody.AddForce(_move.normalized * speed, ForceMode2D.Impulse);
        }
    }
}
