using System;
using UnityEngine;
using Code.Interfaces;
using static UnityEngine.Debug;


namespace Code
{
    public abstract class Health : MonoBehaviour, IDamage, IAlive
    {
        private int _maximumHealth = 200;
        
        public bool IsAlive { get; set; }
        public int HealthObject { get; set; } = 100;
        
        public void TakeDamage(int damage)
        {
            HealthObject -= damage;
            Log("Remaining health units: " + HealthObject);

            if (HealthObject <= 0)
            {
                Die();
                IsAlive = false;

                Time.timeScale = 0;
            }
        }

        public void ReplenishHealth(int healthUnit)
        {
            Log("Good: " + healthUnit + "units");

            HealthObject += healthUnit;

            if (HealthObject > _maximumHealth)
            {
                HealthObject = _maximumHealth;
            } 
            if (HealthObject < _maximumHealth)
            {
                throw new GameException(_maximumHealth);
            }

            Log("Current Health: " + HealthObject + "units");
        }

        protected abstract void Die();
    }
}