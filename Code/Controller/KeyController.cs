using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code
{
    public sealed class KeyController : IController, IInitialization, IKeyController
    {
        public InteractiveObjectData _keyCount;
        private List<Keys> _listKeys;
        public event Action<int> Keys; 

        public KeyController()
        {
            _listKeys = Object.FindObjectsOfType<Keys>().ToList();
            //_keyCount = interactiveObject;
        }

        private void TakeKey(int amount)
        {
            _keyCount.KeyCount += amount;
            Debug.Log($"Current Keys: {_keyCount}");
            
        }

        public void Initialization()
        {
            Keys?.Invoke(_keyCount.KeyCount);
            foreach (var item in _listKeys)
            {
                //item.AddKey += TakeKey;
            }
        }
    }
}