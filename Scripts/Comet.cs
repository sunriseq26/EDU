using UnityEngine;

namespace Asteroids
{
    public class Comet : Enemy
    {
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }

        public void AddRigidbody2D(float mass)
        {
            var rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.mass = mass;
            rigidbody.gravityScale = 0;
        }
    }
}