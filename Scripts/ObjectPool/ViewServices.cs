using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace ObjectPool
{
    public sealed class ViewServices
    {
        private readonly Dictionary<int, ObjectPool> _viewCache = new Dictionary<int, ObjectPool>(12);

        public void Create(GameObject prefab, Transform position)
        {
            if (!_viewCache.TryGetValue(prefab.GetInstanceID(), out ObjectPool viewPool))
            {
                viewPool = new ObjectPool(prefab, position);
                _viewCache[prefab.GetInstanceID()] = viewPool;
            }

            viewPool.Pop();
        }

        public void Destroy(GameObject prefab)
        {
            _viewCache[prefab.GetInstanceID()].Push(prefab); 
        }
    }
}
