using UnityEngine;

namespace Asteroids
{
    public class CometFactory : IEnemyFactory
    {
        private float _mass = 1;
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<Comet>("Enemy/Comet"));
            enemy.DependencyInjectHealth(hp);
            enemy.AddRigidbody2D(_mass);
        
            return enemy;
        }
    }
}