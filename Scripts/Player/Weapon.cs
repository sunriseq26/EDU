using System;
using ObjectPool;
using UnityEngine;

namespace Asteroids
{
    public abstract class Weapon : MonoBehaviour
    {
        public ViewServices ViewServices { get; set; }
        public abstract void Move(Transform barrel, float forceBullet);

        private void OnBecameInvisible()
        {
            ReturnToPool();
        }

        public abstract void ReturnToPool();
    }
}