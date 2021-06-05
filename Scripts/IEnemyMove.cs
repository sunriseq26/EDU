using UnityEngine;

namespace Asteroids
{
    public interface IEnemyMove
    {
        float Speed { get; }
        Rigidbody2D Rigidbody { get; set; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}