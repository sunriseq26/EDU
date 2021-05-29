using UnityEngine;

namespace Asteroids
{
    public class Shoot
    {
        public Shoot(Rigidbody2D bullet, Transform barrel, float forceBullet)
        {
            var temAmmunition = Object.Instantiate(bullet, barrel.position, barrel.rotation);
            temAmmunition.AddForce(barrel.up * forceBullet);
        }
    }
}