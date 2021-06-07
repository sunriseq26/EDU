using UnityEngine;

namespace Asteroids
{
    public class EnemyHealth : IDamage
    {
        public float HealthUnit { get; set; }
        public float Damage { get; }
        public void TakeDamage(float damage)
        {
            HealthUnit -= damage;
                
            Debug.Log("Enemy " + HealthUnit);
        }

        public void ReplenishHealth(float healthUnit)
        {
            throw new System.NotImplementedException();
        }
    }
}