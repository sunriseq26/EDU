using System;
using ObjectPool;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : Weapon
    {
        private Rigidbody2D _rigidbodyBullet;
        
        public delegate void ReturnToPoolBullet();
        public event ReturnToPoolBullet OnReturn;

        private void Awake()
        {
            _rigidbodyBullet = GetComponent<Rigidbody2D>();
            
        }

        public override void Move(Transform barrel, float forceBullet)
        {
            _rigidbodyBullet.AddForce(barrel.up * forceBullet);
        }
        
        public override void ReturnToPool()
        {
            OnReturn();
        }
    }
}