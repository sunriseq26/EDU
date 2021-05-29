using UnityEngine;

namespace Asteroids
{
    public interface IMove
    {
        float Speed { get; }
        Rigidbody2D Rigidbody { get; set; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}
