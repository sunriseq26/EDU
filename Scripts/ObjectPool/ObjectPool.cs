using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    internal sealed class ObjectPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly Transform _startPosition;

        public Stack<GameObject> StackPool => _stack;

        public ObjectPool(GameObject prefab, Transform startPosition)
        {
            _prefab = prefab;
            _startPosition = startPosition;
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.SetActive(false);
        }

        public GameObject Pop()
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
            }
            else
            {
                go = _stack.Pop();
            }
            go.SetActive(true);

            return go;
        }
    }
}
