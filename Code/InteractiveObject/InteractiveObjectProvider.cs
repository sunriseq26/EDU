using System;
using UnityEngine;

namespace Code
{
    public abstract class InteractiveObjectProvider : MonoBehaviour, IInteractiveObject, IComparable<InteractiveObjectProvider>
    {
        protected IView _view;
        protected IHealth _health;
        protected InteractiveObjectData _interactiveObjectData;
        public event Action<IInteractiveObject> OnTriggerEnterChange;
        public bool IsInteractable { get; } = true;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Debug.Log($"Current Keys: {_interactiveObjectData.KeyCount}");
            Interaction();
            OnTriggerEnterChange?.Invoke(this);
            if (!gameObject.GetComponent<InteriorDoor>())
            {
                Destroy(gameObject);
            }
        }

        protected abstract void Interaction();
        
        public void Initialization(IView view, IHealth health, InteractiveObjectData interactiveObjectData)
        {
            _view = view;
            _health = health;
            _interactiveObjectData = interactiveObjectData;
        }

        public int CompareTo(InteractiveObjectProvider other)
        {
            return name.CompareTo(other.name);
        }
    }
}