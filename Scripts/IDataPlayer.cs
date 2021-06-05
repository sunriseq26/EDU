using UnityEngine;

namespace Asteroids
{
    public interface IDataPlayer
    {
        float Speed { get; }
         float Acceleration { get; }
        Rigidbody2D RigidbodyPlayer { get; }
        Transform TransformPlayer { get; }
    }
}