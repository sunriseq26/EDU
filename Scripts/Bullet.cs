using System;
using ObjectPool;
using UnityEngine;

namespace Asteroids
{
    public class Bullet : Weapon
    {
        private Rigidbody2D _rigidbodyBullet;

        private void Start()
        {
            _rigidbodyBullet = GetComponent<Rigidbody2D>();
        }

        public override void Move(Transform barrel, float forceBullet)
        {
            _rigidbodyBullet.AddForce(barrel.up * forceBullet);
        }
    }
}