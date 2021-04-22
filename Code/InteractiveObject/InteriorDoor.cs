using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code
{
    public sealed class InteriorDoor : InteractiveObjectProvider, IEquatable<InteriorDoor>
    {
        
        public event Action<bool> OnSave;
        
        private bool _isOpen = false;
        private Animator _animator;
        //private IKeyController _keysCount;
        private int _keys;

        protected override void Interaction()
        {
            //_keysCount = new KeyController();
            // _keysCount.Keys += GetKeys;
            // Debug.Log(_keys);
            //_keys = _interactiveObjectData;
            _keys = _interactiveObjectData.KeyCount;
            Debug.Log($"Current Keys: {_keys}");
            _animator = GetComponent<Animator>();
            _isOpen = true;
            if (_keys == 1)
            {
                Debug.Log("Enter");
                _animator.SetBool("isOpen", _isOpen);
                
                gameObject.GetComponent<Collider>().enabled = false;
            }
            OnSave?.Invoke(_isOpen);
        }

        public bool Equals(InteriorDoor other)
        {
            return _keys == other._keys;
        }
    }
}