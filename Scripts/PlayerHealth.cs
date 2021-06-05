using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : IDamage
    {
        private float _maximumHealth;

        public float HealthUnit { get; set; }
        
        public PlayerHealth(float health, float maximumHealth)
        {
            HealthUnit = health;
            _maximumHealth = health;
        }
        
        public void ReplenishHealth(float healthUnit)
        {
            if (HealthUnit > _maximumHealth)
            {
                HealthUnit = _maximumHealth;
            }
            else
            {
                HealthUnit += healthUnit;
            }
        }



        public void TakeDamage(float damage)
        {
            if (HealthUnit <= 0)
            {
                Die();
            }
            else
            {
                HealthUnit -= damage;
            }
            Debug.Log(HealthUnit);
        }

        private void Die()
        {
            Time.timeScale = 0;
        }
    }
}