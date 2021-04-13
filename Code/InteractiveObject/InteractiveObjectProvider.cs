using System;
using UnityEngine;

namespace Code
{
    public abstract class InteractiveObjectProvider : MonoBehaviour, IInteractiveObject, IComparable<InteractiveObjectProvider>
    {
        protected IView _view;
        protected IHealth _health;
        public event Action<IInteractiveObject> OnTriggerEnterChange;
        public bool IsInteractable { get; } = true;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            
            Interaction();
            OnTriggerEnterChange?.Invoke(this);
            Destroy(gameObject);
        }

        protected abstract void Interaction();
        
        public void Initialization(IView view, IHealth health)
        {
            _view = view;
            _health = health;
        }
        
        public int CompareTo(InteractiveObjectProvider other)
        {
            return name.CompareTo(other.name);
        }
    }
}