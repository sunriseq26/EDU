using UnityEngine;

namespace Asteroids
{
    public class Comet : Enemy, IEnemyMove
    {
        private Vector3 _move;
        public float Speed { get; private set; }
        public Rigidbody2D Rigidbody { get; set; }
        public void DependencyInjectHealth(Health hp, float speed)
        {
            Health = hp;
            Speed = speed;
        }

        public void AddRigidbody2D(float mass)
        {
            Rigidbody = gameObject.AddComponent<Rigidbody2D>();
            Rigidbody.mass = mass;
            Rigidbody.gravityScale = 0;
        }

        public override void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move = new Vector3(horizontal, horizontal, 0.0f);
            Rigidbody.AddForce(_move.normalized * speed, ForceMode2D.Impulse);
        }
    }
}