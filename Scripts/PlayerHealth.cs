using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : IDamage
    {
        private float _maximumHealth;

        public float Health { get; set; }
        
        public PlayerHealth(float health, float maximumHealth)
        {
            Health = health;
            _maximumHealth = health;
        }
        
        public void ReplenishHealth(int healthUnit)
        {
            if (Health > _maximumHealth)
            {
                Health = _maximumHealth;
            }
            else
            {
                Health += healthUnit;
            }
        }


        public void TakeDamage(int damage)
        {
            if (Health <= 0)
            {
                Die();
            }
            else
            {
                Health -= damage;
            }
        }

        private void Die()
        {
            Time.timeScale = 0;
        }
    }
}