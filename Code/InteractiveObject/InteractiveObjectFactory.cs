using UnityEngine;

namespace Code
{
    public sealed class InteractiveObjectFactory : IInteractiveObjectFactory
    {
        public InteractiveObjectData Data { get; }

        public InteractiveObjectFactory(InteractiveObjectData data)
        {
            Data = data;
        }
        
        public IInteractiveObject CreateInteractiveObject(InteractiveObjectType type)
        {
            var interactiveObjectProvider = Data.GetInteractiveObject(type);
            return Object.Instantiate(interactiveObjectProvider);
        }
    }
}