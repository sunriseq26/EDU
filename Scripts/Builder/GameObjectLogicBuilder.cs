using UnityEngine;

namespace Asteroids.Builder
{
    internal sealed class GameObjectLogicBuilder : GameObjectBuilder
    {
        public GameObjectLogicBuilder(GameObject gameObject) : base(gameObject) {}
        
        public GameObjectLogicBuilder CodeBullet()
        {
            GetOrAddComponent<Bullet>();
            return this;
        }
        
        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}