using System;
using UnityEngine;

namespace Code
{
    public sealed class Keys : InteractiveObjectProvider, IEquatable<Keys>//, IKey
    {
        private int _amount = 1;
        //public event Action<int> AddKey; 
        //private InteractiveObjectData _keys;
        
        protected override void Interaction()
        {
            _interactiveObjectData.KeyCount += _amount;
            Debug.Log($"Current Keys: {_interactiveObjectData.KeyCount}");
        }
        
        // private void TakeKey(int amount)
        // {
        //     _keyCount.KeyCount += amount;
        //     Debug.Log($"Current Keys: {_keyCount}");
        //     
        // }

        public bool Equals(Keys other)
        {
            return _amount == other._amount;
        }
    }
}