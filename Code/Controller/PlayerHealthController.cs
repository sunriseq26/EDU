using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code
{
    public class PlayerHealthController : IExecute, IInitialization, ICleanup, IAlive, IHealth
    {
        private readonly Transform _unit;
        private readonly PlayerData _playerDataHealth;
        private readonly IEnumerable<IInteractiveObject> _getInteractiveObjects;
        private readonly int _getInstanceID;
        //private int _valueHealth;
        private int _maximumValueHealth;

        public bool IsAlive { get; set; } = true;

        public int PlayerHealth { get; set; }

        public PlayerHealthController(PlayerData playerData)
        {
            _playerDataHealth = playerData;
            PlayerHealth = _playerDataHealth.ValueHealth;
            _maximumValueHealth = _playerDataHealth.MaximumValueHealth;
            Debug.Log("Health " + PlayerHealth + " Maximum " + _maximumValueHealth);
        }
        
        
        public void Execute(float deltaTime)
        {
        }

        public void Initialization()
        {
        }
        
        
        public void TakeDamage(int damage)
        {
            PlayerHealth -= damage;
            Log("Remaining health units: " + PlayerHealth);

            if (PlayerHealth < 0)
            {
                PlayerHealth = 0;
            }
            if (PlayerHealth == 0)
            {
                Die();
                IsAlive = false;
                Time.timeScale = 0;
            }
        }

        public void ReplenishHealth(int healthUnit)
        {
            Log("Good: " + healthUnit + "units");

            PlayerHealth += healthUnit;

            if (PlayerHealth > _maximumValueHealth)
            {
                PlayerHealth = _maximumValueHealth;
            }
            
            Log("Current Health: " + PlayerHealth + "units");
        }

        public void Die()
        {
        }
        
        public void Cleanup()
        {
        }
    }
}