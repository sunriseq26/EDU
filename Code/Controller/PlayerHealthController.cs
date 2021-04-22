using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code
{
    public class PlayerHealthController : IExecute, IInitialization, ICleanup, IAlive, IHealth
    {
        //private readonly Transform _unit;
        private readonly PlayerData _playerDataHealth;
        private readonly IEnumerable<IInteractiveObject> _getInteractiveObjects;
        private readonly IEnumerable<IEnemy> _getEnemies;
        private readonly Transform _getPlayer;
        //private int _valueHealth;
        private int _maximumValueHealth;

        public event Action<bool> OnDied;
        public bool IsAlive { get; set; } = true;

        public int PlayerHealth { get; set; }

        public PlayerHealthController(PlayerData playerData, IEnumerable<IEnemy> getEnemies, Transform unit)
        {
            _playerDataHealth = playerData;
            _getEnemies = getEnemies;
            _getPlayer = unit;
            PlayerHealth = _playerDataHealth.ValueHealth;
            _maximumValueHealth = _playerDataHealth.MaximumValueHealth;
            Debug.Log("Health " + PlayerHealth + " Maximum " + _maximumValueHealth);
        }
        
        
        public void Execute(float deltaTime)
        {
        }

        public void Initialization()
        {
            foreach (var enemy in _getEnemies)
            {
                enemy.OnTriggerEnterChange += TakeDamage;
            }
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
                OnDied?.Invoke(Die());
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

        public bool Die()
        {
            IsAlive = false;
            Debug.Log("Enter");
            return IsAlive;
        }
        
        public void Cleanup()
        {
        }
    }
}